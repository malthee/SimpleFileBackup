using SimpleFileBackup.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFileBackup.Core.Data
{
    public class BackupMetadataInfo
    {
        /// <summary>
        /// Dictionary of file path and file size in byte. Invalid files will have size -1.
        /// </summary>
        public IReadOnlyDictionary<string, long> FileSizes { get; }

        /// <summary>
        /// Sum of all file sizes in bytes.
        /// </summary>
        public long FileSizeSum { get; } = 0;

        /// <summary>
        /// Count of files and directories not including nested files.
        /// </summary>
        public long FileCount { get; } = 0;

        /// <summary>
        /// <see langword="true"/>  if the provided files are valid and accessable, otherwise <see langword="false"/>.
        /// </summary>
        public bool FilesValid { get; } = true;

        private BackupMetadataInfo(long fileCount, long fileSizeSum, IReadOnlyDictionary<string, long> fileSizes, bool filesValid)
        {
            FileCount = fileCount;
            FileSizeSum = fileSizeSum;
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
        public Task<BackupMetadataInfo> FromBackupArgumentsAsync(BackupArguments args, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                var fileSizes = new Dictionary<string, long>();
                long fileCount = 0, fileSizeSum = 0;
                bool filesValid = true;

                foreach (string inputFile in args.InputFiles)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    long currentFileSize = GetFileSize(inputFile);

                    if (currentFileSize >= 0)
                    {
                        fileSizeSum += currentFileSize;
                    }
                    else
                    {
                        filesValid = false;
                    }

                    fileSizes.Add(inputFile, currentFileSize);
                    fileCount++;
                }

                return new BackupMetadataInfo(fileCount, fileSizeSum, fileSizes, filesValid);
            });
        }

        /// <summary>
        /// Gets the file size of a single file or whole directory. 
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns>Size in bytes or -1 if read not possible.</returns>
        private static long GetFileSize(string inputFile)
        {
            long size;

            if (Directory.Exists(inputFile))
            {
                var di = new DirectoryInfo(inputFile);
                size = DirectoryHelper.GetRecursiveDirectorySize(di);
            }
            else if (File.Exists(inputFile))
            {
                var fi = new FileInfo(inputFile);
                size = fi.Length;
            }
            else
            {
                size = -1;
            }

            return size;
        }
    }
}
