using System.Text.Encodings.Web;
using System.Text.Json;
using RetroPlaylistMapping.Models;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace RetroPlaylistMapping.Services
{
    public class MapperService(ILogger<MapperService> logger) : IMapperService
    {
        public List<Machine> ReadDatXml()
        {
            const string xmlFileName = @"C:\Projs\RetroPlaylistMapping\RetroPlaylistMapping.App\files\dat\Nintendo - Super Nintendo Entertainment System.xml";
            var doc = XDocument.Load(xmlFileName);
            var tags = doc.Descendants().Where(d => d.Name.LocalName == "machine");
            var serializer = new XmlSerializer(typeof(Machine));
            var maps = tags.Select(t => (Machine)serializer.Deserialize(t.CreateReader())!).ToList();

            return maps;
        }

        public async Task<Playlist> ReadJsonFile()
        {
            var jsonFileName =
                @"C:\Projs\RetroPlaylistMapping\RetroPlaylistMapping.App\files\playlist\Nintendo - Super Nintendo Entertainment System.lpl";
            await using FileStream stream = File.OpenRead(jsonFileName);
            var playlist = await JsonSerializer.DeserializeAsync<Playlist>(stream);
            return playlist;
        }

        public async Task<bool> Run()
        {
            var newJsonFileName =
                @"C:\Projs\RetroPlaylistMapping\RetroPlaylistMapping.App\files\playlist\Nintendo - Super Nintendo Entertainment System 1.lpl";
            var maps = ReadDatXml();
            var playlist = await ReadJsonFile();

            foreach (var item in playlist.Items)
            {
                var map = maps.FirstOrDefault(m => m.Name == item.Label);
                if (map != null)
                {
                    item.Crc32 = $"{map.Rom.Crc}|crc";
                }
                else
                {
                    logger.LogError(Constants.Warning.GameNotFoundOnPlaylist, map.Name);
                }
            }
            
            var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            var jsonString = JsonSerializer.Serialize<Playlist>(playlist, options);
            await File.WriteAllTextAsync(newJsonFileName, jsonString);
            
            return false;
        }
    }
}
