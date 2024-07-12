using RetroPlaylistMapping.Models;

namespace RetroPlaylistMapping.Services;

public interface IMapperService
{
    List<Machine> ReadDatXml();
    Task<Playlist> ReadJsonFile();
    Task<bool> Run();
}