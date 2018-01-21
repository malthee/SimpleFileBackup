using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace SimpleFileBackup
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region form load

        private void FormMain_Load(object sender, EventArgs e)
        {
            //load the default paths for easy regular backups
            if (File.Exists("DefaultBackupPaths.txt"))
            {
                using (StreamReader sr = new StreamReader("DefaultBackupPaths.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        comboBoxBackupLocations.Items.Add(sr.ReadLine());
                    }
                }

                if (comboBoxBackupLocations.Items.Count != 0) //select first item, so the user know something is there
                    comboBoxBackupLocations.SelectedItem = comboBoxBackupLocations.Items[0];
            }

            if (File.Exists("DefaultFilePaths.txt"))
            {
                using (StreamReader sr = new StreamReader("DefaultFilePaths.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        comboBoxFilestobackup.Items.Add(sr.ReadLine());
                    }
                }

                if (comboBoxFilestobackup.Items.Count != 0)
                    comboBoxFilestobackup.SelectedItem = comboBoxFilestobackup.Items[0];
            }
        }

        #endregion

        #region display text

        private async void displayText(string text, int ms, string color)
        {
            if (text == labelInfotext.Text)
            {
                return; //if it's the same message don't display twice
            }

            while (labelInfotext.Text != "")
            {
                await Task.Delay(50); //wait until the last message is done displaying
            }

            if (color.Equals("red"))
                labelInfotext.ForeColor = Color.Red;
            else if (color.Equals("green"))
                labelInfotext.ForeColor = Color.Green;

            labelInfotext.Text = text;
            labelInfotext.Visible = true;
            await Task.Delay(ms);
            labelInfotext.Visible = false;
            labelInfotext.Text = "";
        }

        #endregion

        #region backup files, select and edit

        private void buttonFilestobackup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.ShowDialog();

                if (ofd.FileName == "") //no item selected return
                    return;

                foreach (string s in ofd.FileNames)
                {
                    if (!comboBoxFilestobackup.Items.Contains(s)) //only add if does not exist yet
                        comboBoxFilestobackup.Items.Add(s);
                }

                comboBoxFilestobackup.SelectedItem = comboBoxFilestobackup.Items[comboBoxFilestobackup.Items.Count - 1]; //display last item
            }
        }

        private void buttonFilestobackupClear_Click(object sender, EventArgs e)
        {
            comboBoxFilestobackup.Items.Clear();
            comboBoxFilestobackup.Text = "";
            displayText("Successfully cleared list.", 1500, "green");
        }

        private void comboBoxFilestobackup_KeyDown(object sender, KeyEventArgs e) //add or edit items
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!File.Exists(comboBoxFilestobackup.Text))
                {
                    displayText("File does not exist!", 1500, "red");
                    return;
                }

                if (comboBoxFilestobackup.SelectedItem != null) //delete old item and add new
                    comboBoxFilestobackup.Items.Remove(comboBoxFilestobackup.SelectedItem);

                if (comboBoxFilestobackup.Items.Contains(comboBoxFilestobackup.Text)) //only add if does not exist yet
                {
                    displayText("File already exists!", 1500, "red");
                    return;
                }

                comboBoxFilestobackup.Items.Add(comboBoxFilestobackup.Text);
                displayText("Successfully added item.", 1500, "green");
            }
        }

        private void buttonFilestobackupDeleteitem_Click(object sender, EventArgs e)
        {
            if (comboBoxFilestobackup.SelectedItem != null)
            {
                comboBoxFilestobackup.Items.Remove(comboBoxFilestobackup.SelectedItem);
                comboBoxFilestobackup.Text = "";
                displayText("Successfully deleted item.", 1500, "green");
            }
            else
                displayText("No item to delete!", 1500, "red");

        }

        #endregion

        #region backup locations select and edit

        private void comboBoxBackupLocations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Directory.Exists(comboBoxBackupLocations.Text))
                {
                    displayText("Path does not exist.", 1500, "red");
                    return;
                }

                if (comboBoxBackupLocations.SelectedItem != null) //delete old item and add new
                    comboBoxBackupLocations.Items.Remove(comboBoxBackupLocations.SelectedItem);

                if (comboBoxBackupLocations.Items.Contains(comboBoxBackupLocations.Text))
                {
                    displayText("Directory already exists!", 1500, "red");
                    return;
                }

                comboBoxBackupLocations.Items.Add(comboBoxBackupLocations.Text);
                displayText("Successfully added path.", 1500, "green");
            }
        }

        private void buttonBackupBrowse_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog cof = new CommonOpenFileDialog())
            {
                cof.IsFolderPicker = true;
                if (cof.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (!comboBoxBackupLocations.Items.Contains(cof.FileName))//only add if not yet added
                        comboBoxBackupLocations.Items.Add(cof.FileName);

                    comboBoxBackupLocations.SelectedItem = comboBoxBackupLocations.Items[comboBoxBackupLocations.Items.Count - 1]; //select last added item
                }
                else
                    return; //if the user cancels the dialog

            }
        }

        private void buttonBackupLocationsClear_Click(object sender, EventArgs e)
        {
            comboBoxBackupLocations.Items.Clear();
            comboBoxBackupLocations.Text = "";
            displayText("Successfully cleared list.", 1500, "green");
        }

        private void buttonBackupLocationsDeleteItem_Click(object sender, EventArgs e)
        {
            if (comboBoxBackupLocations.SelectedItem != null)
            {
                comboBoxBackupLocations.Items.Remove(comboBoxBackupLocations.SelectedItem);
                comboBoxBackupLocations.Text = "";
                displayText("Successfully deleted item.", 1500, "green");
            }
            else
                displayText("No item to delete!", 1500, "red");

        }

        #endregion

        #region button ok click

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now; //for adding date to file names
            List<string> backupLocations = new List<string>();
            List<string> backupFiles = new List<string>();
            //taking values from checkboxes and radiobuttons
            bool[] fileSettings = new bool[] { checkBoxOverride.Checked, radioButtonNormal.Checked, radioButtonFolder.Checked, radioButtonZIP.Checked, checkBoxDate.Checked };
            string fname = textBoxName.Text;

            if (comboBoxFilestobackup.Items.Count == 0) //if no files to backup are given
            {
                displayText("No file selected!", 1500, "red");
                return;
            }

            if (comboBoxBackupLocations.Items.Count == 0) //if no backup locations are given
            {
                displayText("No backup path set!", 1500, "red");
                return;
            }

            //fill the lists with the items in the comboboxes
            foreach (string s in comboBoxBackupLocations.Items) { backupLocations.Add(s); }
            foreach (string s in comboBoxFilestobackup.Items) { backupFiles.Add(s); }

            #region check if files, directories exist

            //check if directories still exist
            foreach (string s in backupLocations)
            {
                if (!Directory.Exists(s))
                {
                    displayText("'" + s + "' is not a valid location!", 1500, "red");
                    return;
                }
            }

            //check if files still exist
            foreach (string s in backupFiles)
            {
                if (!File.Exists(s))
                {
                    displayText("'" + s + "' does not exist! Did you delete or move the file?", 1500, "red");
                    return;
                }
            }

            //check if the folder/zip is named
            if ((fileSettings[(int)FSettings.SubFolder] || fileSettings[(int)FSettings.ZipFile]) && (textBoxName.Text.Equals("Name Folder/.zip")||(textBoxName.Text.Trim().Equals(""))))
            {
                displayText("Please enter a name for your Folder/.zip!", 1500, "red");
                return;
            }

            #endregion

            #region prepare and create folders

            if (fileSettings[(int)FSettings.SubFolder])
            {
                foreach (string l in backupLocations)
                {
                    try
                    {
                        //only create if not created yet, add date if the checkbox was checked
                        if (fileSettings[(int)FSettings.AddDateToFileName] && !Directory.Exists(Path.Combine(l, fname + "_" + dt.Day + "-" + dt.Month + "-" + dt.Year)))
                            Directory.CreateDirectory(Path.Combine(l, fname + "_" + dt.Day + "-" + dt.Month + "-" + dt.Year));
                        else if (!Directory.Exists(Path.Combine(l, fname)))
                            Directory.CreateDirectory(Path.Combine(l, fname));
                    }
                    catch (Exception ex)
                    {
                        displayText("Not able to create folder at '" + l + "' maybe invalid foldername or missing permissions?", 3000, "red");
                        Console.WriteLine(ex);
                        return;
                    }
                }
            }

            #endregion

            //used to give the background worker the information he needs
            var bDataEventArgs = new BackupDataArgs(dt, backupLocations, backupFiles, fileSettings, fname);

            progressBarMain.Value = 0;
            buttonOK.Enabled = false; //disable controls in the meantime
            groupBoxSettings.Enabled = false;
            backgroundWorkerBackup.RunWorkerAsync(bDataEventArgs); //everything is alright, we are ready to backup
        }

        #endregion

        #region about info

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAbout fa = new FormAbout())
            {
                fa.ShowDialog();
            }
        }

        #endregion

        #region name textbox 

        private void textBoxName_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Equals("Name Folder/.zip"))
                textBoxName.Text = "";
        }
        //^v when entering the textboxname delete the standard text
        private void textBoxName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (textBoxName.Text.Equals("Name Folder/.zip"))
                textBoxName.Text = "";
        }

        #endregion

        #region settings

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Name.Equals("radioButtonNormal"))
            {
                //toggle controls, which can only be used when rbfolder or rbzip is checked
                textBoxName.Enabled = false;
                textBoxName.Text = "Name Folder/.zip";
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

        #region save and open paths.txt

        private void saveDefaultBackupPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("DefaultBackupPaths.txt", false))
            {
                foreach (string s in comboBoxBackupLocations.Items)
                {
                    sw.WriteLine(s);
                }

                displayText("Successfully saved default backup paths.", 1500, "green");
            }
        }

        private void saveDefaultFilePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("DefaultFilePaths.txt", false))
            {
                foreach (string s in comboBoxFilestobackup.Items)
                {
                    sw.WriteLine(s);
                }

                displayText("Successfully saved default file paths.", 1500, "green");
            }
        }

        private void openFilePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files|*.txt";
                ofd.ShowDialog();
                if (ofd.FileName != "")
                {
                    comboBoxFilestobackup.Items.Clear();

                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            comboBoxFilestobackup.Items.Add(sr.ReadLine());
                        }
                    }

                    if (comboBoxFilestobackup.Items.Count != 0) //select first item, so the user know something is there
                        comboBoxFilestobackup.SelectedItem = comboBoxFilestobackup.Items[0];

                    displayText("Successfully opened '" + ofd.FileName + "'", 1500, "green");
                }
            }
        }

        private void openBackupPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files|*.txt";
                ofd.ShowDialog();
                if (ofd.FileName != "")
                {
                    comboBoxBackupLocations.Items.Clear();

                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            comboBoxBackupLocations.Items.Add(sr.ReadLine());
                        }
                    }

                    if (comboBoxBackupLocations.Items.Count != 0) //select first item, so the user know something is there
                        comboBoxBackupLocations.SelectedItem = comboBoxBackupLocations.Items[0];

                    displayText("Successfully opened '" + ofd.FileName + "'", 1500, "green");
                }
            }
        }

        private void saveCustomFilePathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.Filter = "Text files|*.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        foreach (string s in comboBoxFilestobackup.Items)
                        {
                            sw.WriteLine(s);
                        }

                        displayText("Successfully saved custom file paths.", 1500, "green");
                    }
                }

            }
        }

        private void saveCustomBackupPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.Filter = "Text files|*.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        foreach (string s in comboBoxBackupLocations.Items)
                        {
                            sw.WriteLine(s);
                        }

                        displayText("Successfully saved custom backup paths.", 1500, "green");
                    }
                }

            }
        }

        #endregion

        #region backgroundworker 

        private void DoBackup(BackgroundWorker bgWorker, DoWorkEventArgs e)
        {
            BackupDataArgs backupData = e.Argument as BackupDataArgs;

            int currentProgress = 0;
            bgWorker.ReportProgress(currentProgress);

            //zip progressvalue is calculated different from copy progressvalue
            int progressValue = (backupData.FileSettings[(int)FSettings.ZipFile]) ? 40 / (backupData.BackupFiles.Count) : 80 / (backupData.BackupFiles.Count * backupData.BackupLocations.Count);
            //add this number every time a file is copied, not that accurate but w/e
            MessageBox.Show(progressValue.ToString());
            //shows that everything works and is ready to copy
            currentProgress = 20;

            #region copy files

            //if the files are being copied into a subfolder or the given folder
            if (backupData.FileSettings[(int)FSettings.SubFolder] || backupData.FileSettings[(int)FSettings.GivenDirectory])
            {
                foreach (string f in backupData.BackupFiles) //copy each file to every backup location, f=file, l=location
                {
                    foreach (string l in backupData.BackupLocations)
                    {
                        try
                        {
                            if (backupData.FileSettings[(int)FSettings.GivenDirectory])  //copy files in given directory
                            {
                                File.Copy(f, Path.Combine(l, Path.GetFileName(f)), backupData.FileSettings[(int)FSettings.Override]);
                            }

                            else if (backupData.FileSettings[(int)FSettings.SubFolder])
                            {
                                if (backupData.FileSettings[(int)FSettings.AddDateToFileName])    //create subfolder and add date to foldername
                                    File.Copy(f, Path.Combine(l, backupData.FileName + "_" + backupData.DTNow.Day + "-" + backupData.DTNow.Month + "-" + backupData.DTNow.Year, Path.GetFileName(f)), backupData.FileSettings[(int)FSettings.Override]);
                                else                        //just create a subfolder
                                    File.Copy(f, Path.Combine(l, backupData.FileName, Path.GetFileName(f)), backupData.FileSettings[(int)FSettings.Override]);
                            }

                            currentProgress = (currentProgress + progressValue < 100) ? currentProgress + progressValue : 100; //100 is maximum, if it would go above just set it 100
                            bgWorker.ReportProgress(currentProgress);
                            MessageBox.Show(currentProgress.ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }

            #endregion

            #region files in zip

            else //make a zip file 
            {
                if (!Directory.Exists(backupData.FileName)) //create temporary folder to make zip
                {   
                    Directory.CreateDirectory(backupData.FileName);
                }

                foreach (string f in backupData.BackupFiles)
                {
                    File.Copy(f, Path.Combine(backupData.FileName, Path.GetFileName(f)), true);
                    currentProgress = (currentProgress + progressValue < 60) ? currentProgress + progressValue : 60; //60 is maximum for this operation, if it goes above just set it to 60
                    bgWorker.ReportProgress(currentProgress);
                }

                //adjust progressvalue to locations, 35% progress for locations
                progressValue = 35 / backupData.BackupLocations.Count;

                foreach (string l in backupData.BackupLocations) //copy zip to every location
                {
                    if (backupData.FileSettings[(int)FSettings.Override])//if overriding is true, delete old identical zip files
                    {
                        try
                        {
                            if (File.Exists(Path.Combine(l, backupData.FileName + "_" + backupData.DTNow.Day + "-" + backupData.DTNow.Month + "-" + backupData.DTNow.Year + ".zip")))
                                File.Delete(Path.Combine(l, backupData.FileName + "_" + backupData.DTNow.Day + "-" + backupData.DTNow.Month + "-" + backupData.DTNow.Year + ".zip"));

                            if (File.Exists(Path.Combine(l, backupData.FileName + ".zip")))
                                File.Delete(Path.Combine(l, backupData.FileName + ".zip"));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            e.Cancel = true;
                            return;
                        }
                    }

                    try
                    {
                        if (checkBoxDate.Checked)
                            ZipFile.CreateFromDirectory(backupData.FileName, Path.Combine(l, backupData.FileName + "_" + backupData.DTNow.Day + "-" + backupData.DTNow.Month + "-" + backupData.DTNow.Year + ".zip"));
                        else
                            ZipFile.CreateFromDirectory(backupData.FileName, Path.Combine(l, backupData.FileName + ".zip"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        e.Cancel = true;
                        return;
                    }

                    currentProgress = (currentProgress + progressValue < 95) ? currentProgress + progressValue : 95; //95 is maximum for this operation
                    bgWorker.ReportProgress(currentProgress);
                }

                bgWorker.ReportProgress(95);
                Directory.Delete(backupData.FileName, true);
            }

            #endregion
        }

        private void backgroundWorkerBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            DoBackup(sender as BackgroundWorker, e);
        }

        private void backgroundWorkerBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarMain.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            groupBoxSettings.Enabled = true; //enable controls again
            buttonOK.Enabled = true;

            if (e.Cancelled)
            {
                //TODO: undo work that has been done upon the point, when the program is canceled & give out more detailed error messages
                displayText("Successfully cancelled", 3000, "red");
                progressBarMain.Value = 0;
            }
            else
            {
                progressBarMain.Value = 100;
                displayText("File backup successful", 3000, "green");
            }
        }

        #endregion

        #region fsettings enum

        //for easy access in the filesettings array
        public enum FSettings
        {
            Override = 0, GivenDirectory, SubFolder, ZipFile, AddDateToFileName
        }

        #endregion
    }
}
