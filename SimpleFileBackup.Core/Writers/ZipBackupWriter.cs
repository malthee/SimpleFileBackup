using SimpleFileBackup.Core.Data;
using SimpleFileBackup.Core.Progress;
using SimpleFileBackup.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFileBackup.Core.Writers
{
    internal class ZipBackupWriter : NamedBackupWriter
    {
        public ZipBackupWriter(BackupArguments backupArguments, string fileName, DateTime dateSuffix, string dateFormat)
            : base(backupArguments, fileName, dateSuffix, dateFormat)
        {
        }

        public ZipBackupWriter(BackupArguments backupArguments, string fileName)
            : base(backupArguments, fileName)
        {
        }

        public override Task PerformBackup(CancellationToken cancellationToken = default, IBackupProgress progress = null)
        {
            return Task.Run(() =>
            {
                var outputDirs = backupArgs.OutputDirs.GetEnumerator();
                if (!outputDirs.MoveNext()) return;

                string originZip = CreateZipFromArguments(outputDirs.Current, cancellationToken, progress);
                long dirCount = 1;
                long zipSize = new FileInfo(originZip).Length;
                progress.Report(new BackupProgressInfo(dirCount / (double)backupArgs.OutputDirs.Count, zipSize));

                // Copy the zip into other outputs
                while (outputDirs.MoveNext())
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Directory.CreateDirectory(outputDirs.Current);
                    File.Copy(originZip, Path.Combine(outputDirs.Current, backupName + ".zip"), backupArgs.OverwriteExisting);

                    dirCount++;
                    if (progress != null)
                    {
                        progress.Report(new BackupProgressInfo(dirCount / (double)backupArgs.OutputDirs.Count, zipSize * dirCount));
                    }
                }
            }, cancellationToken);
        }

        /// <summary>
        /// Creates a new zip archive with all input files from <see cref="BackupArguments"/>. Deletes existing file first if overwrite existing is enabled.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Path to the new zip file.</returns>
        private string CreateZipFromArguments(string location, CancellationToken cancellationToken, IBackupProgress progress = null)
        {
            BackupProgressHelper progressHelper = progress == null ? null : new BackupProgressHelper(backupArgs, progress.BackupMetadataInfo);

            // Create zip in first backup dir, delete first if exists
            var fileLocation = Path.Combine(location, backupName + ".zip");
            if (backupArgs.OverwriteExisting)
            {
                File.Delete(fileLocation);
            }

            // Add all input files and directories to zip
            using (var zipFile = ZipFile.Open(fileLocation, ZipArchiveMode.Create))
            {
                foreach (var inputFile in backupArgs.InputFiles)
                {
                    zipFile.CreateEntryFromAny(inputFile);
                    if (progressHelper != null)
                    {
                        // While creating zip bytesBackedUp will stay 0
                        progress.Report(progressHelper.AddProgressByFile(inputFile).WithBytesBackedUp(0));
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }

            return fileLocation;
        }
    }
}
