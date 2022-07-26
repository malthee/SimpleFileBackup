using SimpleFileBackup.Core.Data;
using SimpleFileBackup.Core.Progress;
using SimpleFileBackup.Core.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            BackupProgressHelper progressHelper = progress == null ? null : new BackupProgressHelper(backupArgs, progress.BackupMetadataInfo);

            return Task.Run(() =>
            {
                // Copy each file into each dir
                foreach (var outputDir in backupArgs.OutputDirs)
                {
                    foreach (var inputFile in backupArgs.InputFiles)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        Directory.CreateDirectory(outputDir);
                        DirectoryHelper.CopyFileOrDirectory(inputFile, outputDir, backupArgs.OverwriteExisting);
                        progress?.Report(progressHelper.AddProgressByFile(inputFile));
                    }
                }
            }, cancellationToken);
        }
    }
}
