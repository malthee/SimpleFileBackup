using System;
using System.Collections.Generic;

namespace SimpleFileBackup.Windows
{
    class BackupDataArgs : EventArgs
    {
        public DateTime DTNow { get; set; }
        public List<string> BackupLocations { get; set; }
        public List<string> BackupFiles { get; set; }
        public bool[] FileSettings { get; set; }
        public string FileName { get; set; }

        public BackupDataArgs(DateTime dt, List<string> backupLocations, List<string> backupFiles, bool[] fileSettings, string fname)
        {
            DTNow = dt;
            BackupLocations = backupLocations;
            BackupFiles = backupFiles;
            FileSettings = fileSettings;
            FileName = fname;
        }
    }
}
