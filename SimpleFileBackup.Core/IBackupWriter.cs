using SimpleFileBackup.Core.Progress;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFileBackup.Core
{
    public interface IBackupWriter
    {
        /// <summary>
        /// Backs up all input files and folders to their output directories. 
        /// Reports progress through <paramref name="progress"/>. Cancellable through <paramref name="cancellationToken"/>.
        /// Does not revert changes on cancellation.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        Task ExecuteAsync(CancellationToken cancellationToken, IBackupProgress progress);

        /// <summary>
        /// Backs up all input files and folders to their output directories. 
        /// Is cancellable through <paramref name="cancellationToken"/>.
        /// Does not revert changes on cancellation.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ExecuteAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Backs up all input files and folders to their output directories. 
        /// Reports progress through <paramref name="progress"/>.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        Task ExecuteAsync(IBackupProgress progress);

        /// <summary>
        /// Backs up all input files and folders to their output directories. 
        /// </summary>
        /// <returns></returns>
        Task ExecuteAsync();
    }
}
