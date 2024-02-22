using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

//Ensure that the keys can be accessed by both apps
//Ensure that the application name are the same for both apps
builder.Services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(@"C:\Files\Keys"))
        .SetApplicationName("ABCAPP");


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
        {
            //Ensure that the domaim is the same for both apps
            //o.Cookie.Domain = "";
        });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello From Identity Sever!");
app.MapGet("/protected", () => "Hello Protected From Identity Sever!").RequireAuthorization();
app.MapGet("/login", async (HttpContext ctx) =>
{
    await ctx.SignInAsync(new ClaimsPrincipal(
        new[]
        {
            new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, "mail@test.co")
            },
            CookieAuthenticationDefaults.AuthenticationScheme)
        })
        );
    return "Ok";
});

app.Run();
