using SimpleFileBackup.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFileBackup.Core.Writers
{
    /// <summary>
    /// Base class for backup writers that allow setting a name with optional date suffix.
    /// </summary>
    internal abstract class NamedBackupWriter : BaseBackupWriter
    {
        protected readonly string backupName;

        public NamedBackupWriter(BackupArguments backupArguments, string backupName, DateTime dateSuffix, string dateFormat) : this(backupArguments, backupName)
        {
            this.backupName = dateSuffix != null ? $"{backupName}_{dateSuffix.ToString(dateFormat)}" : backupName;
        }

        public NamedBackupWriter(BackupArguments backupArguments, string backupName) : base(backupArguments)
        {
            if (string.IsNullOrWhiteSpace(backupName))
            {
                throw new ArgumentException($"'{nameof(backupName)}' cannot be null or whitespace.", nameof(backupName));
            }

            this.backupName = backupName;
        }
    }
}
