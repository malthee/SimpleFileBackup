using SimpleFileBackup.Core.Data;
using SimpleFileBackup.Core.Progress;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFileBackup.Core.Util
{
    internal class BackupProgressHelper
    {
        private readonly BackupArguments backupArguments;
        private readonly BackupMetadataInfo metadataInfo;

        public BackupProgressHelper(BackupArguments backupArguments, BackupMetadataInfo metadataInfo)
        {
            this.backupArguments = backupArguments ?? throw new ArgumentNullException(nameof(backupArguments));
            this.metadataInfo = metadataInfo ?? throw new ArgumentNullException(nameof(metadataInfo));
        }

        public BackupProgressInfo CurrentProgress { get; private set; } = new BackupProgressInfo(0, 0);

        /// <summary>
        /// Gets a new <see cref="BackupProgressInfo"/> increased by the progress depending on the file size of the <paramref name="inputFile"/> and the 
        /// count of output directories in <see cref="BackupArguments"/>.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
        public BackupProgressInfo AddProgressByFile(string inputFile)
        {
            metadataInfo.FileSizes.TryGetValue(inputFile, out long fileSize);

            // (1 for each file + size) / ((sizesum + filecount) * output location count)
            double percentIncrease = (1 + fileSize) / (double)((metadataInfo.FileSizeSum + backupArguments.InputFiles.Count) * backupArguments.OutputDirs.Count);

            var newProgress = new BackupProgressInfo(
                percentDone: Math.Min(1, CurrentProgress.PercentDone + percentIncrease), // prevent going over 1
                bytesBackedUp: CurrentProgress.BytesBackedUp + fileSize);

            return CurrentProgress = newProgress;
        }
    }
}
