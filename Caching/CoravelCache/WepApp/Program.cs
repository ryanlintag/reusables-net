using Coravel;
using Coravel.Cache.Interfaces;
using WepApp.Helpers;
using WepApp.Models;
using WepApp.Repository;
using WepApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCache();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ILongRunningService, LongRunningService>();

var app = builder.Build();

app.MapGet("/", async (ICache cache, ILongRunningService service) => {
    var result = await service.GetItems();
    return result;
});
app.MapGet("/anotherRequest1", async (ICache cache, ILongRunningService service) => {
    var result = await service.GetItems();
    return result;
});
app.MapGet("/anotherRequest2", async (ICache cache, ILongRunningService service) => {
    var result = await service.GetItems();
    return result;
});
app.MapGet("/anotherRequest3", async (ICache cache, ILongRunningService service) => {
    var result = await service.GetItems();
    return result;
});

app.Run();
