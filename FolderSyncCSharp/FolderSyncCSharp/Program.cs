using FolderSyncCSharp;
using System;
using System.Threading;


namespace FolderSyncCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: FolderSyncCSharp.exe <source_folder> <replica_folder> <log_file> <interval>");
                return;
            }

            string sourceFolder = args[0];
            string replicaFolder = args[1];
            string logFilePath = args[2];
            int interval = int.Parse(args[3]);

            Logger logger = new Logger(logFilePath);

            try
            {
                while (true)
                {
                    Sync.SynchronizeFolders(sourceFolder, replicaFolder);
                    logger.LogOperation("Folders synchronized");

                    Thread.Sleep(interval * 1000);
                }
            }
            catch (Exception ex)
            {
                logger.LogOperation($"Error: {ex.Message}");
            }
        }
    }
}
