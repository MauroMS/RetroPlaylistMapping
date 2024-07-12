namespace RetroPlaylistMapping.Models;

public class Constants
{
    public static class Exceptions { }

    public static class Information
    {
        public const string ApplicationStarted = "Application Started";
        public const string ApplicationStopped = "Application Stopped";
    }

    public static class Warning
    {
        public const string GameNotFoundOnPlaylist = "Game '{game}' not found on playlist";
    }
}