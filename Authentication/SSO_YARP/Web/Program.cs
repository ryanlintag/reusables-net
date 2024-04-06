using System.Security.Claims;
using System.Text.Json;
using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(tbc => { 
        if(!string.IsNullOrEmpty(tbc.Route.AuthorizationPolicy))
        {
            tbc.AddRequestTransform(rtc =>
            {
                var userDictionary = rtc.HttpContext.User.Claims.Aggregate(
                    new Dictionary<string, string>(), (d, c) =>
                    {
                        d[c.Type] = c.Value;
                        return d;
                    }
                );
                rtc.ProxyRequest.Headers.Add("x-user-json", JsonSerializer.Serialize(userDictionary));
                rtc.ProxyRequest.Headers.Add("x-api-key", Guid.NewGuid().ToString());
                return ValueTask.CompletedTask;
            });
        }
    });

builder.Services.AddAuthentication("cookie").AddCookie("cookie");

var app = builder.Build();

app.MapReverseProxy();

app.MapGet("/", (ClaimsPrincipal cp) =>
    cp.Claims.Aggregate(
            new Dictionary<string, string>(), (d,c) =>
            {
                d[c.Type] = c.Value;
                return d;
            }
        )
);

app.MapGet("/loginCompliance", () => Results.SignIn(
    new ClaimsPrincipal(
        new ClaimsIdentity(
            new Claim[] 
            { 
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, "ryanlintag@gmail.com"),
                new Claim(ClaimTypes.Name, "Ryan")
            },
            "cookie")        
        ),
        authenticationScheme: "cookie"
    )
);

app.Run();
