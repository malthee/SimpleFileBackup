using SimpleFileBackup.Core.Data;
using SimpleFileBackup.Core.Progress;
using SimpleFileBackup.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFileBackup.Core.Writers
{
    internal class SubfolderCopyBackupWriter : NamedBackupWriter
    {
        public SubfolderCopyBackupWriter(BackupArguments backupArguments, string subfolderName, DateTime dateSuffix, string dateFormat)
            : base(backupArguments, subfolderName, dateSuffix, dateFormat)
        {
        }

        public SubfolderCopyBackupWriter(BackupArguments backupArguments, string subfolderName)
            : base(backupArguments, subfolderName)
        {
        }

        public override Task PerformBackup(CancellationToken cancellationToken = default, IBackupProgress progress = null)
        {
            BackupProgressHelper progressHelper = progress == null ? null : new BackupProgressHelper(backupArgs, progress.BackupMetadataInfo);

            return Task.Run(() =>
            {
                // Copy each file into each dir, create new subdir
                foreach (var outputDir in backupArgs.OutputDirs)
                {
                    var outputSubDir = Directory.CreateDirectory(Path.Combine(outputDir, backupName));

                    foreach (var inputFile in backupArgs.InputFiles)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        DirectoryHelper.CopyFileOrDirectory(inputFile, outputSubDir.FullName, backupArgs.OverwriteExisting);
                        progress?.Report(progressHelper.AddProgressByFile(inputFile));
                    }
                }
            }, cancellationToken);
        }
    }
}
