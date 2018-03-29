using System.IO;

namespace Twitteranalyze
{
    internal partial class FileIO
    {
        public class DirectoryGroup
        {
            public static void MkDir(string DirPath)
            {
                Directory.CreateDirectory(DirPath);
            }

            public static bool Exists(string DirPath)
            {
                if (Directory.Exists(DirPath))
                    return true;

                return false;
            }

        }
    }
}
