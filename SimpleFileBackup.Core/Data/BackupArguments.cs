using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFileBackup.Core.Data
{
    /// <summary>
    /// Data class with arguments needed to perform a backup. 
    /// </summary>
    public class BackupArguments
    {
        /// <summary>
        /// May be paths to files or folders.
        /// </summary>
        public IEnumerable<string> InputFiles { get; }

        /// <summary>
        /// Folder paths of output directories.
        /// </summary>
        public IEnumerable<string> OutputDirs { get; }

        /// <summary>
        /// Defines if existing files should be overwritten.
        /// </summary>
        public bool OverwriteExisting { get; }

        public BackupArguments(IEnumerable<string> inputFiles, IEnumerable<string> outputDirs, bool overwriteExisting)
        {
            InputFiles = inputFiles;
            OutputDirs = outputDirs;
            OverwriteExisting = overwriteExisting;
        }
    }
}
