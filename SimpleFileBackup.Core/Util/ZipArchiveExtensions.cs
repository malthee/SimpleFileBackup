using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Linq;

namespace SimpleFileBackup.Core.Util
{
    // https://stackoverflow.com/a/51514527
    public static class ZipArchiveExtensions
    {
        /// <summary>
        /// Creates a new entry in the zip either from a file or directory.
        /// </summary>
        /// <param name="archive"></param>
        /// <param name="sourceName"></param>
        /// <param name="pathPrefix"></param>
        public static void CreateEntryFromAny(this ZipArchive archive, string sourceName, string pathPrefix = "")
        {
            var fileName = Path.GetFileName(sourceName);
            if (File.GetAttributes(sourceName).HasFlag(FileAttributes.Directory))
            {
                archive.CreateEntryFromDirectory(sourceName, Path.Combine(pathPrefix, fileName));
            }
            else
            {
                archive.CreateEntryFromFile(sourceName, Path.Combine(pathPrefix, fileName), CompressionLevel.Fastest);
            }
        }

        /// <summary>
        /// Creates a new entry in the zip keeping the structure of the input directory.
        /// </summary>
        /// <param name="archive"></param>
        /// <param name="sourceDirName"></param>
        /// <param name="pathPrefix"></param>
        public static void CreateEntryFromDirectory(this ZipArchive archive, string sourceDirName, string pathPrefix = "")
        {
            string[] files = Directory.GetFiles(sourceDirName).Concat(Directory.GetDirectories(sourceDirName)).ToArray();

            foreach (var file in files)
            {
                archive.CreateEntryFromAny(file, pathPrefix);
            }
        }
    }
}
