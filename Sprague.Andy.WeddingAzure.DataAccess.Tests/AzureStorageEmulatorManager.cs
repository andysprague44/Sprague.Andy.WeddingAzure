using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Sprague.Andy.WeddingAzure.DataAccess.Tests
{
    // Start/stop azure storage emulator from code:
    // http://stackoverflow.com/questions/7547567/how-to-start-azure-storage-emulator-from-within-a-program
    //
    public static class AzureStorageEmulatorManager
    {
        private static string WindowsAzureStorageEmulatorPath => ConfigurationManager.AppSettings["WindowsAzureStorageEmulatorPath"];
        private const string Win7ProcessName = "WAStorageEmulator";
        private const string Win8ProcessName = "WASTOR~1";
        private const string Win10ProcessName = "AzureStorageEmulator";

        private static ProcessStartInfo StartStorageEmulatorInfo => new ProcessStartInfo
        {
            FileName = WindowsAzureStorageEmulatorPath,
            Arguments = "start",
        };

        private static ProcessStartInfo StopStorageEmulatorInfo => new ProcessStartInfo
        {
            FileName = WindowsAzureStorageEmulatorPath,
            Arguments = "stop",
        };

        private static Process GetProcess()
        {
            return Process.GetProcessesByName(Win10ProcessName).FirstOrDefault() ??
                   Process.GetProcessesByName(Win8ProcessName).FirstOrDefault() ??
                   Process.GetProcessesByName(Win7ProcessName).FirstOrDefault();
        }

        public static bool IsProcessStarted()
        {
            return GetProcess() != null;
        }

        public static void StartStorageEmulator()
        {
            if (!IsProcessStarted())
            {
                using (var process = Process.Start(StartStorageEmulatorInfo))
                {
                    if (process == null)
                    {
                        throw new Exception("Could not start StorageEmulator, process is null");
                    }
                    process.WaitForExit();
                }
            }
        }

        public static void StopStorageEmulator()
        {
            using (var process = Process.Start(StopStorageEmulatorInfo))
            {
                if (process == null)
                {
                    throw new Exception("Could not start StorageEmulator, process is null");
                }
                process.WaitForExit();
            }
        }
    }
}