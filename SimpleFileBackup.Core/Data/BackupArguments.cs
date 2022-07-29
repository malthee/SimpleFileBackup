using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleFileBackup.Core.Data
{
    /// <summary>
    /// Data class with arguments needed to perform a backup. 
    /// </summary>
    public class BackupArguments
    {
        /// <summary>
        /// Paths to files or folders.
        /// </summary>
        public IReadOnlyList<string> InputFiles { get; }

        /// <summary>
        /// Folder paths of output directories.
        /// </summary>
        public IReadOnlyList<string> OutputDirs { get; }

        /// <summary>
        /// Defines if existing files should be overwritten.
        /// </summary>
        public bool OverwriteExisting { get; }

        /// <summary>
        /// Creates a new instance with copies of <paramref name="inputFiles"/> and <paramref name="outputDirs"/>.
        /// </summary>
        /// <param name="inputFiles"></param>
        /// <param name="outputDirs"></param>
        /// <param name="overwriteExisting"></param>
        public BackupArguments(IEnumerable<string> inputFiles, IEnumerable<string> outputDirs, bool overwriteExisting)
        {
            InputFiles = inputFiles.ToList();
            OutputDirs = outputDirs.ToList();
            OverwriteExisting = overwriteExisting;
        }
    }
}
