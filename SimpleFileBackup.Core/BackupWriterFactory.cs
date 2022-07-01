using SimpleFileBackup.Core.Data;
using SimpleFileBackup.Core.Writers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleFileBackup.Core
{
    /// <summary>
    /// Factory for <see cref="IBackupWriter"/> implementations. 
    /// </summary>
    public class BackupWriterFactory
    {
        /// <summary>
        /// Arguments used to create <see cref="IBackupWriter"/>s with.
        /// </summary>
        public BackupArguments BackupArguments { get; set; }

        public BackupWriterFactory(BackupArguments args)
        {
            BackupArguments = args;
        }

        public IBackupWriter CreateCopyFileBackupWriter()
        {
            return new CopyFileBackupWriter(BackupArguments);
        }
    }
}
