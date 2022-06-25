using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleFileBackup.Core.Util
{
    public static class DirectoryHelper
    {
        /// <summary>
        /// Get the full size of a directory and all of its subfolders recursively.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long GetRecursiveDirectorySize(DirectoryInfo d)
        {
            long size = 0;
            // Add directory file sizes.
            foreach (FileInfo fi in d.GetFiles())
            {
                size += fi.Length;
            }

            // Add subdirectory sizes.
            foreach (DirectoryInfo di in d.GetDirectories())
            {
                size += GetRecursiveDirectorySize(di);
            }
            return size;
        }

        /// <summary>
        /// Copies all files and subfolders of source into target, keeping the file structure.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="overwrite"></param>
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target, bool overwrite)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
            {
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name), overwrite);
            }

            foreach (FileInfo file in source.GetFiles())
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), overwrite);
            }
        }
    }
}
