using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SimpleFileBackup.Core.Util
{
    internal static class DirectoryHelper
    {
        /// <summary>
        /// Get the full size and count of files of a directory and all of its subfolders recursively.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static (long Size, long Count) GetRecursiveDirectorySize(DirectoryInfo d)
        {
            long size = 0, count = 0;
            // Add directory file sizes.
            foreach (FileInfo fi in d.GetFiles())
            {
                size += fi.Length;
                count++;
            }

            // Add subdirectory sizes.
            foreach (DirectoryInfo di in d.GetDirectories())
            {
                var (s, c) = GetRecursiveDirectorySize(di);
                count += c;
                size += s;
            }

            return (size, count);
        }

        /// <summary>
        /// Copies all files and subfolders of source into target, keeping the file structure.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="overwriteExisting"></param>
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target, bool overwriteExisting)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name), overwriteExisting);
            }

            // Keep input folder structure
            var outputDir = Path.Combine(target.FullName, source.Name);
            Directory.CreateDirectory(outputDir);

            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(outputDir, file.Name), overwriteExisting);
            }
        }

        /// <summary>
        /// Copies a file or a whole directory recursively into <paramref name="outputDir"/>.
        /// May throw exceptions from IO access.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputDir"></param>
        /// <param name="overwriteExisting"></param>
        public static void CopyFileOrDirectory(string inputFile, string outputDir, bool overwriteExisting)
        {
            if (Directory.Exists(inputFile))
            {
                CopyFilesRecursively(new DirectoryInfo(inputFile), new DirectoryInfo(outputDir), overwriteExisting);
            }
            else // Should be file, throws exception when does not exist.
            {
                string fileName = Path.GetFileName(inputFile);
                File.Copy(inputFile, Path.Combine(outputDir, fileName), overwriteExisting);
            }
        }
    }
}
