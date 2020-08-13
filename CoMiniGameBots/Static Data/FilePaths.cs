using System.IO;

namespace CoMiniGameBots.Static_Data
{

    public static class FilePaths
    {
        public static string BuildFilePath(string file)
        {
            return Path.Combine(DataDirectory, file);
        }
        public static string DataDirectory { get; } = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "Data");
    }
}
