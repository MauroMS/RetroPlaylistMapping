using System.Text.Json.Serialization;

namespace RetroPlaylistMapping.Models;

public class Playlist
{
    [JsonPropertyName("version")] public string Version { get; set; }

    [JsonPropertyName("default_core_path")]
    public string DefaultCorePath { get; set; }

    [JsonPropertyName("default_core_name")]
    public string DefaultCoreName { get; set; }

    [JsonPropertyName("base_content_directory")]
    public string BaseContentDirectory { get; set; }

    [JsonPropertyName("label_display_mode")]
    public int LabelDisplayMode { get; set; }

    [JsonPropertyName("right_thumbnail_mode")]
    public int RightThumbnailMode { get; set; }

    [JsonPropertyName("left_thumbnail_mode")]
    public int LeftThumbnailMode { get; set; }

    [JsonPropertyName("sort_mode")] public int SortMode { get; set; }

    [JsonPropertyName("items")] public List<PlaylistItem> Items { get; set; } = [];

    // [JsonPropertyName("scan_content_dir")]
    // public string ScanContentDir { get; set; }
    //
    // [JsonPropertyName("scan_file_exts")]
    // public string ScanFileExts { get; set; }
    //
    // [JsonPropertyName("scan_dat_file_path")]
    // public string ScanDatFilePath { get; set; }
    //
    // [JsonPropertyName("scan_search_recursively")]
    // public bool ScanSearchRecursively { get; set; }
    //
    // [JsonPropertyName("scan_search_archives")]
    // public bool ScanSearchArchives { get; set; }
    //
    // [JsonPropertyName("scan_search_archives")]
    // public bool ScanFilterDatContent { get; set; }
    //
    // [JsonPropertyName("scan_overwrite_playlist")]
    // public bool ScanOverwritePlaylist { get; set; }
}

public class PlaylistItem
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyOrder(2)]
    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyOrder(3)]
    [JsonPropertyName("core_path")]
    public string CorePath { get; set; }

    [JsonPropertyOrder(4)]
    [JsonPropertyName("core_name")]
    public string CoreName { get; set; }

    [JsonPropertyOrder(5)]
    [JsonPropertyName("crc32")]
    public string Crc32 { get; set; }

    [JsonPropertyOrder(6)]
    [JsonPropertyName("db_name")]
    public string DbName { get; set; }
}