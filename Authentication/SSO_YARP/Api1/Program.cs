using Api1;
using Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISecretReader, SecretReader>();
builder.Services.AddSingleton<IEncryption, AesEncryption>();


var app = builder.Build();

app.UseMiddleware<SecurityHeaderChekerMiddleware>();

app.MapGet("/", async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello World from api 1!");

    foreach (var item in context.Items)
    {
        await context.Response.WriteAsJsonAsync($"{item.Key}: {item.Value} \n");
    }
}); 

app.Run();
