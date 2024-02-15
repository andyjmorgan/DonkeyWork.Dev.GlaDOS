using DonkeyWork.Dev.GladOS.WikipediaConnector.Interface;
using DonkeyWork.Dev.GladOS.WikipediaConnector.Service;

WikipediaConnector wc = new WikipediaConnector();
await wc.GetGlaDOSQuotesAsync();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Memory cache.
builder.Services.AddMemoryCache();

// Add Wikipedia Connector
builder.Services.AddTransient<IWikipediaConnector, WikipediaConnector>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();
