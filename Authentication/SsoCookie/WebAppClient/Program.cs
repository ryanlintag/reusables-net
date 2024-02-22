using Microsoft.AspNetCore.Authentication.Cookies;
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

app.MapGet("/", () => "Hello World from client!");
app.MapGet("/protected", () => "Hello Protected from client!").RequireAuthorization();

app.Run();
