using SimpleFileBackup.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFileBackup.Core.Data
{
    /// <summary>
    /// Contains metadata about the input files of a backup.
    /// </summary>
    public class BackupMetadataInfo
    {
        /// <summary>
        /// Dictionary of file path and file size in byte. Invalid files will have size -1.
        /// </summary>
        public IReadOnlyDictionary<string, long> FileSizes { get; }

        /// <summary>
        /// Count of all files including those nested in directories.
        /// </summary>
        public long FileCount { get; }

        /// <summary>
        /// Sum of all file sizes in bytes.
        /// </summary>
        public long FileSizeSum { get; }

        /// <summary>
        /// <see langword="true"/>  if the provided files are valid and accessable, otherwise <see langword="false"/>.
        /// </summary>
        public bool FilesValid { get; } = true;

        private BackupMetadataInfo(long fileSizeSum, long fileCount, IReadOnlyDictionary<string, long> fileSizes, bool filesValid)
        {
            FileSizeSum = fileSizeSum;
            FileCount = fileCount;
            FileSizes = fileSizes;
            FilesValid = filesValid;
        }

        /// <summary>
        /// Creates a new <see cref="BackupMetadataInfo"/> from <see cref="BackupArguments"/>. Gets file and directory size info.
        /// Includes file duplicates in size and count.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<BackupMetadataInfo> FromBackupArgumentsAsync(BackupArguments args, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                var fileSizes = new Dictionary<string, long>();
                long fileSizeSum = 0, fileCount = 0;
                bool filesValid = true;

                foreach (string inputFile in args.InputFiles)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    (long currentFileSize, long currentCount) = GetFileOrFolderSize(inputFile);

                    if (currentFileSize >= 0)
                    {
                        fileSizeSum += currentFileSize;
                    }
                    else
                    {
                        filesValid = false;
                    }

                    fileCount += currentCount; 
                    fileSizes.Add(inputFile, currentFileSize);
                }

                return new BackupMetadataInfo(fileSizeSum, fileCount, fileSizes, filesValid);
            });
        }

        /// <summary>
        /// Gets the file size and count of a single file or whole directory. 
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns>Size in bytes or -1 if read not possible and count of file(s).</returns>
        private static (long Size, long Count) GetFileOrFolderSize(string inputFile)
        {
            long size = -1, count = 1;

            if (Directory.Exists(inputFile))
            {
                var di = new DirectoryInfo(inputFile);
                (size, count) = DirectoryHelper.GetRecursiveDirectorySize(di);
            }
            else if (File.Exists(inputFile))
            {
                var fi = new FileInfo(inputFile);
                size = fi.Length;
            }

            return (size, count);
        }
    }
}
