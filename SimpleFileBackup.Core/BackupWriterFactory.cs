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
        public BackupArguments BackupArguments { get; }

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
