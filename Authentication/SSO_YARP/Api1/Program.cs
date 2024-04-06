using Api1;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<SecurityHeaderChekerMiddleware>();

app.MapGet("/", () => "Hello World from api 1!");

app.Run();
