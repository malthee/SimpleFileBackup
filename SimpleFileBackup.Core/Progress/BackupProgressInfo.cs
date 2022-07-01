using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFileBackup.Core.Progress
{
    /// <summary>
    /// Provides information about a running backup.
    /// </summary>
    public class BackupProgressInfo
    {
        /// <summary>
        /// How much progress the backup has made. Does not have to be related to bytes backed up.
        /// </summary>
        public double PercentDone { get; }

        /// <summary>
        /// How many bytes were backed up to output locations.
        /// </summary>
        public long BytesBackedUp { get; }

        public BackupProgressInfo(double percentDone, long bytesBackedUp)
        {
            PercentDone = percentDone;
            BytesBackedUp = bytesBackedUp;
        }
    }
}
