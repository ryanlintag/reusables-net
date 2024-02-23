using IdentityServer.Repositories;
using IdentityServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IAuthenticationService, LdapAuthenticationService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
