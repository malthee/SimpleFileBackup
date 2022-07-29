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
        public const string DefaultDateFormat = "dd-MM-yyyy";

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

        public IBackupWriter CreateSubfolderCopyBackupWriter(string subfolderName)
        {
            return new SubfolderCopyBackupWriter(BackupArguments, subfolderName);
        }

        public IBackupWriter CreateSubfolderCopyBackupWriter(string subfolderName, DateTime dateSuffix, string dateFormat = DefaultDateFormat)
        {
            return new SubfolderCopyBackupWriter(BackupArguments, subfolderName, dateSuffix, dateFormat);
        }

        public IBackupWriter CreateZipBackupWriter(string zipName)
        {
            return new ZipBackupWriter(BackupArguments, zipName);
        }

        public IBackupWriter CreateZipBackupWriter(string zipName, DateTime dateSuffix, string dateFormat = DefaultDateFormat)
        {
            return new ZipBackupWriter(BackupArguments, zipName, dateSuffix, dateFormat);
        }
    }
}
