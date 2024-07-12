using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RetroPlaylistMapping.Models;
using RetroPlaylistMapping.Services;

namespace RetroPlaylistMapping.App;

public class MapWorker(ILogger<MapWorker> logger, IMapperService mapperService) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation(Constants.Information.ApplicationStarted);
        // var test = mapperService.ReadDatXml();
        // var test1 = mapperService.ReadJsonFile();
        await mapperService.Run();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation(Constants.Information.ApplicationStopped);
        await Task.CompletedTask;
    }
}