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
    /// Sets up the base arguments for a BackupWriter and routes ExecuteAsync overloads with default parameters.
    /// </summary>
    internal abstract class BaseBackupWriter : IBackupWriter
    {
        protected readonly BackupArguments backupArgs;

        internal BaseBackupWriter(BackupArguments backupArguments)
        {
            this.backupArgs = backupArguments;
        }

        /// <summary>
        /// Performs the backup with provided arguments.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public abstract Task PerformBackup(CancellationToken cancellationToken = default, IBackupProgress progress = null);

        #region ExecuteAsync overloads, argument check

        public async Task ExecuteAsync(CancellationToken cancellationToken, IBackupProgress progress)
        {
            if (progress is null)
            {
                throw new ArgumentNullException(nameof(progress));
            }

            if (progress is null)
            {
                throw new ArgumentNullException(nameof(progress));
            }

            await PerformBackup(cancellationToken, progress);
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await PerformBackup(cancellationToken);
        }

        public async Task ExecuteAsync(IBackupProgress progress)
        {
            if (progress is null)
            {
                throw new ArgumentNullException(nameof(progress));
            }

            await PerformBackup(progress: progress);
        }

        public async Task ExecuteAsync()
        {
            await PerformBackup();
        }

        #endregion
    }
}
