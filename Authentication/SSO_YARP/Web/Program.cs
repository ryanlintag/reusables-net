using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

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
