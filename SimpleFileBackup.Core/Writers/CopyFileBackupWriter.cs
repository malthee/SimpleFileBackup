using SimpleFileBackup.Core.Data;
using SimpleFileBackup.Core.Progress;
using SimpleFileBackup.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFileBackup.Core.Writers
{
    /// <summary>
    /// Writer that copies files from locations into other locations.
    /// </summary>
    internal class CopyFileBackupWriter : BaseBackupWriter
    {
        public CopyFileBackupWriter(BackupArguments backupArguments) : base(backupArguments)
        {
        }

        public override Task PerformBackup(CancellationToken cancellationToken = default, IBackupProgress progress = null)
        {
            return Task.Run(() =>
            {
                var progressInfo = new BackupProgressInfo(0, 0);

                // Copy each file into each dir
                foreach (var inputFile in backupArgs.InputFiles)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    BackupFile(inputFile);

                    if (progress != null)
                    {
                        ReportProgress(inputFile, progress, progressInfo);
                    }
                }
            }, cancellationToken);
        }

        private void BackupFile(string inputFile)
        {
            if (Directory.Exists(inputFile))
            {
                foreach (var outputDir in backupArgs.OutputDirs)
                {
                    DirectoryHelper.CopyFilesRecursively(new DirectoryInfo(inputFile), new DirectoryInfo(outputDir), backupArgs.OverwriteExisting);
                }
            }
            else // Should be file, throws exception when does not exist.
            {
                string fileName = Path.GetFileName(inputFile);

                foreach (var outputDir in backupArgs.OutputDirs)
                {
                    File.Copy(inputFile, Path.Combine(outputDir, fileName), backupArgs.OverwriteExisting);
                }
            }
        }

        private void ReportProgress(string inputFile, IBackupProgress progress, BackupProgressInfo progressInfo)
        {
            var metadataInfo = progress.BackupMetadataInfo;
            metadataInfo.FileSizes.TryGetValue(inputFile, out long fileSize);
            double percentIncrease = fileSize / (metadataInfo.FileSizeSum + double.Epsilon); // prevent div 0
            progressInfo.PercentDone += Math.Min(100, progressInfo.PercentDone + percentIncrease);
            progressInfo.BytesBackedUp += fileSize;
            progress?.Report(progressInfo.MemberwiseClone());
        }
    }
}
