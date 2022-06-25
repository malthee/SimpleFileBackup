using SimpleFileBackup.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFileBackup.Core.Progress
{
    /// <summary>
    /// <see cref="Progress{T}"/> implementation with <see cref="BackupProgressInfo"/> requiring a <see cref="Core.BackupMetadataInfo"/> 
    /// for progress calculation.
    /// <br/><inheritdoc/>
    /// </summary>
    public class BackupProgress : Progress<BackupProgressInfo>, IBackupProgress
    {
        public BackupMetadataInfo BackupMetadataInfo { get; }

        // Hide default constructor because of required Metadata argument
        private BackupProgress()
        { }

        /// <summary>
        /// Initializes a <see cref="BackupProgress"/> instance.
        /// </summary>
        /// <param name="backupMetadataInfo"></param>
        public BackupProgress(BackupMetadataInfo backupMetadataInfo)
        {
            BackupMetadataInfo = backupMetadataInfo;
        }

        /// <summary>
        /// Initializes a <see cref="BackupProgress"/> with a handler.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="backupMetadataInfo"></param>
        public BackupProgress(Action<BackupProgressInfo> handler, BackupMetadataInfo backupMetadataInfo) : base(handler)
        {
            BackupMetadataInfo = backupMetadataInfo;
        }
    }
}
