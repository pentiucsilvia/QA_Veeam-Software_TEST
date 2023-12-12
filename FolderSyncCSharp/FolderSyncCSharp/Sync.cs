using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FolderSyncCSharp
{
    class Sync
    {
        public static void SynchronizeFolders(string sourceFolder, string replicaFolder)
        {
            if (Directory.Exists(replicaFolder))
            {
                Directory.Delete(replicaFolder, true);
            }

            CopyAll(new DirectoryInfo(sourceFolder), new DirectoryInfo(replicaFolder));
        }

        private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }

            foreach (DirectoryInfo subDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(subDir.Name);
                CopyAll(subDir, nextTargetSubDir);
            }
        }
    }
}
