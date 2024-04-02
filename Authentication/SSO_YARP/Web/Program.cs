var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

//builder.Services.AddCors(option =>
//{
//    option.AddPolicy("allowAll", builder => builder.AllowAnyOrigin());
//});

var app = builder.Build();

//app.UseCors("allowAll");

app.MapReverseProxy();

app.MapGet("/", () => "Hello World!");

app.Run();
