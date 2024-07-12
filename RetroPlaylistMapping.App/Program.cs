using Microsoft.Extensions.Hosting;
using RetroPlaylistMapping.App;

var builder = Host.CreateApplicationBuilder(args);
builder.ConfigureServices();

Console.WriteLine("Hello, World!");

var host = builder.Build();

await host.StartAsync();

await host.StopAsync();