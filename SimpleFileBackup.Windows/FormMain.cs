using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Microsoft.WindowsAPICodePack.Dialogs;
using SimpleFileBackup.Core.Data;
using SimpleFileBackup.Core;
using SimpleFileBackup.Core.Progress;
using System.Threading;
using System.Security.Cryptography;
using System.Linq;
using System.Collections.Specialized;

namespace SimpleFileBackup.Windows
{
    /// <summary>
    /// Logic behind the SimpleFileBackup Windows Forms User Controls.
    /// </summary>
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region DisplayText

        private CancellationTokenSource displayCancellation = new CancellationTokenSource();

        private async void DisplayText(string text, int ms, Color color)
        {
            if (text == labelInfotext.Text)
            {
                return; // If it's the same message don't display twice
            }

            displayCancellation?.Cancel(); // Cancel old message
            using (var currentTokenSource = new CancellationTokenSource())
            {
                displayCancellation = currentTokenSource;
                labelInfotext.ForeColor = color;
                labelInfotext.Text = text;
                labelInfotext.Visible = true;
                try
                {
                    await Task.Delay(ms, currentTokenSource.Token);
                    labelInfotext.Visible = false; // Only hide when no other display task has started
                    labelInfotext.Text = "";
                }
                catch (OperationCanceledException) { } // ignored
                finally { displayCancellation = null; }
            }
        }

        #endregion

        /* --- Form Events --- */

        #region Form Load, Init Paths and Settings

        private void FormMain_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            var inputFiles = settings.InputFiles?.Cast<string>().ToArray();
            if (inputFiles != null && inputFiles.Length > 0)
            {
                comboBoxFilestobackup.Items.AddRange(inputFiles);
                comboBoxFilestobackup.SelectedItem = comboBoxFilestobackup.Items[0];
            }

            var outputDirs = settings.OutputDirectories?.Cast<string>().ToArray();
            if (outputDirs != null && outputDirs.Length > 0)
            {
                comboBoxBackupLocations.Items.AddRange(outputDirs);
                comboBoxBackupLocations.SelectedItem = comboBoxBackupLocations.Items[0];
            }

            if (Enum.TryParse<BackupMode>(settings.BackupMode.ToString(), out var mode))
            {
                radioButtonNormal.Checked = mode == BackupMode.Copy;
                radioButtonFolder.Checked = mode == BackupMode.Subfolder;
                radioButtonZIP.Checked = mode == BackupMode.Zip;
            }

            checkBoxDate.Checked = settings.AddDate;
            checkBoxOverride.Checked = settings.Overwrite;
            textBoxName.Text = settings.BackupName;
        }

        #endregion

        #region Select Backup Files or Folders

        private void ButtonFilestobackup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Multiselect = true })
            {
                ofd.ShowDialog();

                if (ofd.FileName == "") //no item selected cancel
                    return;

                foreach (string s in ofd.FileNames)
                {
                    if (!comboBoxFilestobackup.Items.Contains(s)) //only add if does not exist yet
                        comboBoxFilestobackup.Items.Add(s);
                }

                comboBoxFilestobackup.SelectedItem = comboBoxFilestobackup.Items[comboBoxFilestobackup.Items.Count - 1]; //display last item
            }
        }

        private void ButtonFolderstobackup_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog cof = new CommonOpenFileDialog { IsFolderPicker = true, Multiselect = true })
            {
                if (cof.ShowDialog() != CommonFileDialogResult.Ok)
                    return; //if the user cancels the dialog

                foreach (string s in cof.FileNames)
                {
                    if (!comboBoxFilestobackup.Items.Contains(s)) //only add if does not exist yet
                        comboBoxFilestobackup.Items.Add(s);
                }

                comboBoxFilestobackup.SelectedItem = comboBoxFilestobackup.Items[comboBoxFilestobackup.Items.Count - 1]; //display last item
            }
        }

        private void ButtonFilestobackupClear_Click(object sender, EventArgs e)
        {
            comboBoxFilestobackup.Items.Clear();
            comboBoxFilestobackup.Text = "";
            DisplayText("Successfully cleared list.", 1500, Color.Green);
        }

        private void ComboBoxFilestobackup_KeyDown(object sender, KeyEventArgs e) //add or edit items
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!File.Exists(comboBoxFilestobackup.Text) && !Directory.Exists(comboBoxFilestobackup.Text))
                {
                    DisplayText("File or directory does not exist!", 1500, Color.Red);
                    return;
                }

                if (comboBoxFilestobackup.SelectedItem != null) //delete old item and add new
                    comboBoxFilestobackup.Items.Remove(comboBoxFilestobackup.SelectedItem);

                if (comboBoxFilestobackup.Items.Contains(comboBoxFilestobackup.Text)) //only add if does not exist yet
                {
                    DisplayText("File or directory already exists!", 1500, Color.Red);
                    return;
                }

                comboBoxFilestobackup.Items.Add(comboBoxFilestobackup.Text);
                DisplayText("Successfully added item.", 1500, Color.Green);
            }
        }

        private void ButtonFilestobackupDeleteitem_Click(object sender, EventArgs e)
        {
            if (comboBoxFilestobackup.SelectedItem != null)
            {
                comboBoxFilestobackup.Items.Remove(comboBoxFilestobackup.SelectedItem);
                comboBoxFilestobackup.Text = "";
                DisplayText("Successfully deleted item.", 1500, Color.Green);
            }
            else
                DisplayText("No item to delete!", 1500, Color.Red);

        }

        #endregion

        #region Select Backup Locations

        private void ComboBoxBackupLocations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DirectoryInfo dir;
                try
                {
                    // Create dir if not exists already
                    dir = Directory.CreateDirectory(comboBoxBackupLocations.Text);
                }
                catch (Exception ex)
                {
                    DisplayText(ex.Message, 1500, Color.Red);
                    return;
                }

                if (comboBoxBackupLocations.SelectedItem != null) //delete old item and add new
                    comboBoxBackupLocations.Items.Remove(comboBoxBackupLocations.SelectedItem);

                if (comboBoxBackupLocations.Items.Contains(dir.FullName))
                {
                    DisplayText("Directory already exists!", 1500, Color.Red);
                    return;
                }

                comboBoxBackupLocations.Items.Add(dir.FullName);
                DisplayText("Successfully added path.", 1500, Color.Green);
            }
        }

        private void ButtonBackupBrowse_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog cof = new CommonOpenFileDialog { IsFolderPicker = true, Multiselect = true })
            {
                if (cof.ShowDialog() != CommonFileDialogResult.Ok)
                    return; //if the user cancels the dialog

                foreach (string s in cof.FileNames)
                {
                    if (!comboBoxBackupLocations.Items.Contains(s)) //only add if not yet added
                        comboBoxBackupLocations.Items.Add(s);
                }

                comboBoxBackupLocations.SelectedItem = comboBoxBackupLocations.Items[comboBoxBackupLocations.Items.Count - 1]; //select last added item
            }
        }

        private void ButtonBackupLocationsClear_Click(object sender, EventArgs e)
        {
            comboBoxBackupLocations.Items.Clear();
            comboBoxBackupLocations.Text = "";
            DisplayText("Successfully cleared list.", 1500, Color.Green);
        }

        private void ButtonBackupLocationsDeleteItem_Click(object sender, EventArgs e)
        {
            if (comboBoxBackupLocations.SelectedItem != null)
            {
                comboBoxBackupLocations.Items.Remove(comboBoxBackupLocations.SelectedItem);
                comboBoxBackupLocations.Text = "";
                DisplayText("Successfully deleted item.", 1500, Color.Green);
            }
            else
                DisplayText("No item to delete!", 1500, Color.Red);

        }

        #endregion

        #region Show About

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAbout fa = new FormAbout())
            {
                fa.ShowDialog();
            }
        }

        #endregion

        #region Set Backup Name 

        private const string BackupNamePlaceholder = "Name Folder/.zip";

        private void TextBoxName_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Equals(BackupNamePlaceholder))
                textBoxName.Text = "";
        }
        //^v when entering the textboxname delete the standard text
        private void TextBoxName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (textBoxName.Text.Equals(BackupNamePlaceholder))
                textBoxName.Text = "";
        }

        #endregion

        #region Radio Buttons

        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb == radioButtonNormal)
            {
                // Toggle controls, which can only be used when rbfolder or rbzip is checked
                textBoxName.Enabled = false;
                textBoxName.Text = BackupNamePlaceholder;
                checkBoxDate.Enabled = false;
                checkBoxDate.Checked = false;
            }
            else
            {
                textBoxName.Enabled = true;
                checkBoxDate.Enabled = true;
            }
        }

        #endregion

        /* --- Saved Settings and Locations --- */

        #region Settings Save

        private void SaveDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            settings.AddDate = checkBoxDate.Checked;
            settings.Overwrite = checkBoxOverride.Checked;
            settings.BackupName = textBoxName.Text;
            var inputFiles = new StringCollection();
            inputFiles.AddRange(comboBoxFilestobackup.Items.Cast<string>().ToArray());
            var outputDirs = new StringCollection();
            outputDirs.AddRange(comboBoxBackupLocations.Items.Cast<string>().ToArray());
            settings.InputFiles = inputFiles;
            settings.OutputDirectories = outputDirs;
            settings.BackupMode =
                radioButtonZIP.Checked ? (uint)BackupMode.Zip :
                radioButtonFolder.Checked ? (uint)BackupMode.Subfolder :
                 (uint)BackupMode.Copy;

            settings.Save();
            DisplayText("Successfully saved default values.", 1500, Color.Green);
        }

        #endregion

        #region Save and Open persisted Backup Path files

        private void OpenPaths_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            ComboBox boxToFill;

            if (menuItem == openFilePathsToolStripMenuItem)
                boxToFill = comboBoxFilestobackup;
            else if (menuItem == openBackupPathsToolStripMenuItem)
                boxToFill = comboBoxBackupLocations;
            else
                throw new NotSupportedException("Invalid menu item.");

            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Text files|*.txt" })
            {
                ofd.ShowDialog();
                if (ofd.FileName != "")
                {
                    boxToFill.Items.Clear();

                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        int linesRead = 0;
                        while (!sr.EndOfStream)
                        {
                            string readData = sr.ReadLine();
                            // v1.1 Removed restrictions
                            //if (linesRead > 50 || readData.Length > 200)
                            //    break; //maximum of lines read should be around 50 and max lenght of path should be 200 to prevent memory problems
                            boxToFill.Items.Add(readData);
                            linesRead++;
                        }
                    }

                    if (boxToFill.Items.Count != 0) //select first item, so the user know something is there
                        boxToFill.SelectedItem = boxToFill.Items[0];

                    DisplayText("Successfully opened '" + ofd.FileName + "'", 1500, Color.Green);
                }
            }
        }

        private void SaveCustomFilePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { AddExtension = true, Filter = "Text files|*.txt" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        foreach (string s in comboBoxFilestobackup.Items)
                        {
                            sw.WriteLine(s);
                        }

                        DisplayText("Successfully saved custom file paths.", 1500, Color.Green);
                    }
                }
            }
        }

        private void SaveCustomBackupPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { AddExtension = true, Filter = "Text files|*.txt" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        foreach (string s in comboBoxBackupLocations.Items)
                        {
                            sw.WriteLine(s);
                        }

                        DisplayText("Successfully saved custom backup paths.", 1500, Color.Green);
                    }
                }

            }
        }

        #endregion

        /* ---- Backup Logic --- */

        #region Backup

        private CancellationTokenSource backupCancellation = new CancellationTokenSource();

        private bool ValidateArguments(BackupArguments backupArgs)
        {
            if (comboBoxFilestobackup.Items.Count == 0) // If no files to backup are given
            {
                DisplayText("No file selected!", 1500, Color.Red);
                return false;
            }

            if (comboBoxBackupLocations.Items.Count == 0) // If no backup locations are given
            {
                DisplayText("No backup path set!", 1500, Color.Red);
                return false;
            }

            // Check if files still exist
            foreach (string s in backupArgs.InputFiles)
            {
                if (!File.Exists(s) && !Directory.Exists(s))
                {
                    DisplayText("'" + s + "' does not exist!", 1500, Color.Red);
                    return false;
                }
            }

            // Check if the folder/zip is named
            if ((radioButtonFolder.Checked || radioButtonZIP.Checked) && (textBoxName.Text.Equals("Name Folder/.zip") || (textBoxName.Text.Trim().Equals(""))))
            {
                DisplayText("Please enter a name for your Folder/.zip!", 1500, Color.Red);
                return false;
            }

            return true;
        }

        private async void ButtonOK_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now; // For adding date to file names
            BackupArguments backupArgs = new BackupArguments(comboBoxFilestobackup.Items.Cast<string>(), comboBoxBackupLocations.Items.Cast<string>(), checkBoxOverride.Checked);

            // First validate input
            if (!ValidateArguments(backupArgs)) return;

            ResetBackupUi();

            backupCancellation?.Cancel(); // Cancel currently running backup if not cancelled already
            var currentTokenSource = new CancellationTokenSource();
            backupCancellation = currentTokenSource;
            BackupWriterFactory factory = new BackupWriterFactory(backupArgs);
            BackupMetadataInfo meta = await BackupMetadataInfo.FromBackupArgumentsAsync(backupArgs);
            BackupProgress progress = new BackupProgress(ReportBackupProgress, meta);
            IBackupWriter writer;

            if (radioButtonNormal.Checked) { writer = factory.CreateCopyFileBackupWriter(); }
            else if (radioButtonFolder.Checked) { writer = checkBoxDate.Checked ? factory.CreateSubfolderCopyBackupWriter(textBoxName.Text, dt) : factory.CreateSubfolderCopyBackupWriter(textBoxName.Text); }
            else if (radioButtonZIP.Checked) { writer = checkBoxDate.Checked ? factory.CreateZipBackupWriter(textBoxName.Text, dt) : factory.CreateZipBackupWriter(textBoxName.Text); }
            else { throw new NotSupportedException("Unsupported BackupWriter."); }

            labelProgress.Text = string.Format("{0} files and {1:n0} KB input", meta.FileCount, meta.FileSizeSum / 1000);

            try
            {
                await writer.ExecuteAsync(currentTokenSource.Token, progress);
                progressBarMain.Value = 100;
                DisplayText("File backup successful.", 3000, Color.Green);
            }
            catch (Exception ex)
            {
                progressBarMain.Value = 0;
                if (ex is OperationCanceledException)
                    DisplayText("Successfully cancelled Backup.", 3000, Color.Green);
                else
                    DisplayText(ex.Message, 3000, Color.Red);
            }
            finally
            {
                buttonOK.Visible = true; // Enable controls again
                buttonCancel.Visible = false;
                groupBoxSettings.Enabled = true;
                backupCancellation = null;
                currentTokenSource.Dispose();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            backupCancellation.Cancel();
            DisplayText("Cancellation requested.", 3000, Color.Black);
            buttonCancel.Enabled = false;
        }

        private void ReportBackupProgress(BackupProgressInfo info)
        {
            progressBarMain.Value = (int)(info.PercentDone * 100);
            labelProgress.Text = labelProgress.Text.Split('\n')[0]
                + string.Format("\n{0:n0} KB written to output", info.BytesBackedUp / 1000);
        }

        private void ResetBackupUi()
        {
            buttonOK.Visible = false; // Disable and switch controls in the meantime
            buttonCancel.Visible = true;
            buttonCancel.Enabled = true;
            groupBoxSettings.Enabled = false;
            progressBarMain.Value = 0;
            labelProgress.Text = "";
        }

        #endregion
    }
}
