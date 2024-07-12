using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RetroPlaylistMapping.Services;
using Serilog;

namespace RetroPlaylistMapping.App;

public static class EnvironmentConfiguration
{
    public static IConfiguration ConfigureAppSettings(string[] args)
    {
        IConfiguration configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        return configurationBuilder;
    }

    public static IHostApplicationBuilder ConfigureServices(this IHostApplicationBuilder builder)
    {
        var configuration = ConfigureAppSettings([]);
        // builder.Services.Configure<SyncBackup>(configuration.GetSection("SyncBackup"));
        builder.Services.AddSerilog(lc => lc.ReadFrom.Configuration(builder.Configuration));

        builder.Services.AddScoped<IMapperService, MapperService>();
        // builder.Services.AddSingleton<IAuthService, AuthService>();
        // builder.Services.AddTransient<IUploadService, UploadService>();
        // builder.Services.AddTransient<IDownloadService, DownloadService>();
        // builder.Services.AddTransient<ICloudStorageRepository, CloudStorageRepository>();
        // builder.Services.AddTransient<ILocalStorageRepository, LocalStorageRepository>();

        builder.Services.AddHostedService<MapWorker>();
        return builder;
    }
}