using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoMiniGameBots.Static_Data
{

    public static class FilePaths
    {
        private static string _DataDirectory = Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "Data");
        public static string BuildFilePath(string file)
        {
            return Path.Combine(_DataDirectory, file);
        }
        public static string DataDirectory
        {
            get { return _DataDirectory; }
        }

    }
}
