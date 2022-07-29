using SimpleFileBackup.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFileBackup.Core.Progress
{
    /// <summary>
    /// Extends <see cref="IProgress{T}"/> with a <see cref="Data.BackupMetadataInfo"/> for progress calculation.
    /// <br/><inheritdoc/>
    /// </summary>
    public interface IBackupProgress : IProgress<BackupProgressInfo>
    {
        BackupMetadataInfo BackupMetadataInfo { get; }
    }
}
