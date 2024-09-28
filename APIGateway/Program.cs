
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// إضافة دعم Ocelot
builder.Services.AddOcelot();

var app = builder.Build();

// إعداد Ocelot Middleware
await app.UseOcelot();

app.Run();
