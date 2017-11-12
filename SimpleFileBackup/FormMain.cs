using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        /*If someone ever gets to read this source code:
         * Hello, at the time I am writing this I am a 17 year old student from Austria (date 16.08.2017).
         * I coded this because I wanted a tool to backup my KeePass files to more locations at once.
         * d
         * Contact: salvenmarcel@gmail.com */

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

            if(color.Equals("red"))
                labelInfotext.ForeColor = Color.Red;
            else if(color.Equals("green"))
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
            if(e.KeyCode == Keys.Enter) 
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

        private void buttonOK_Click(object sender, EventArgs e)
        {
            progressBarMain.Value = 0;
            
            #region check if files, directories exist

            if (comboBoxFilestobackup.Items.Count == 0) //if no files to backup are given
            {
                displayText("No file selected!", 1500, "red");
                return;
            }

            if (comboBoxBackupLocations.Items.Count==0) //if no backup locations are given
            {
                displayText("No backup path set!", 1500, "red");
                return;
            }

            //check if directories still exist
            foreach(string s in comboBoxBackupLocations.Items)
            {
                if (!Directory.Exists(s))
                {
                    displayText("'"+ s + "' is not a valid location!",1500, "red");
                    return;
                }
            }

            //check if files still exist
            foreach(string s in comboBoxFilestobackup.Items)
            {
                if (!File.Exists(s))
                {
                    displayText("'" + s + "' does not exist! Did you delete or move the file?", 1500, "red");
                    return;
                }
            }

            if (radioButtonFolder.Checked&&textBoxName.Text.Equals("Name Folder/.zip")) //check if is named
            {
                displayText("Please enter a name for your Folder/.zip!", 1500, "red");
                return;
            }

            #endregion

            #region variables, objects and lists

            DateTime dt = DateTime.Now; //for adding date to file names
            List<string> backupLocations = new List<string>(); //avoids users changing the comboboxes while working
            List<string> backupFiles = new List<string>();
            string fname = textBoxName.Text;
            bool over = checkBoxOverride.Checked; //identical files in directory get overriden if true
            foreach(string s in comboBoxBackupLocations.Items) { backupLocations.Add(s); }
            foreach(string s in comboBoxFilestobackup.Items) { backupFiles.Add(s); }

            #endregion

            groupBoxSettings.Enabled = false; //keep the user from pressing the button or changing something in settings while working
            buttonOK.Enabled = false;

            #region folder creation

            if (radioButtonFolder.Checked)
            { 
                foreach(string l in backupLocations)
                {
                    try
                    {
                        if (checkBoxDate.Checked&&!Directory.Exists(Path.Combine(l, fname + "_" + dt.Day + "-" + dt.Month + "-" + dt.Year))) //only create if not created yet
                            Directory.CreateDirectory(Path.Combine(l,fname + "_" + dt.Day + "-" + dt.Month + "-" + dt.Year));
                        else if(!Directory.Exists(Path.Combine(l, fname)))
                            Directory.CreateDirectory(Path.Combine(l,fname));
                    }
                    catch(Exception ex)
                    {
                        displayText("Not able to create folder at '" + l + "' maybe invalid foldername or missing permissions?", 3000, "red");
                        Console.WriteLine(ex); 
                        groupBoxSettings.Enabled = true; //enable controls again
                        buttonOK.Enabled = true;
                        return;
                    }
                }
            }

            #endregion

            progressBarMain.Value = 20;
            int progress = backupFiles.Count * backupLocations.Count;
            progress = 80 / progress +1; //add this number every time a file is copied, not that accurate but w/e

            #region copy files

            if (radioButtonFolder.Checked || radioButtonNormal.Checked)
            { 
                foreach (string f in backupFiles) //copy each file to every backup location, f=file, l=location
                {
                    foreach (string l in backupLocations)
                    {
                        try
                        { 
                            if (radioButtonNormal.Checked)  //copy files in given directory
                            {
                                File.Copy(f,Path.Combine(l, Path.GetFileName(f)),over);
                            }
                            else if (radioButtonFolder.Checked)
                            {
                                if(checkBoxDate.Checked)    //create subfolder and add date to foldername
                                    File.Copy(f, Path.Combine(l, fname + "_" + dt.Day + "-" + dt.Month + "-" + dt.Year, Path.GetFileName(f)),over);
                                else                        //just create a subfolder
                                    File.Copy(f, Path.Combine(l, fname, Path.GetFileName(f)),over);
                            }

                            if (progressBarMain.Value + progress < 100) { progressBarMain.Value += progress; } //only add if does not reach 100, prevents errorsr
                        }
                        catch(Exception ex)
                        {
                            groupBoxSettings.Enabled = true; //enable controls again
                            buttonOK.Enabled = true;

                            Console.WriteLine(ex);
                            progressBarMain.Value = 0;
                            displayText(ex.Message, 3000, "red");
                            return;
                        }
                    }
                }
            }

            #endregion

            #region files in zip

            else //make a zip file 
            {
                if (!Directory.Exists(fname)) //create temporary folder to make zip
                    Directory.CreateDirectory(fname);

                foreach (string f in backupFiles)
                {
                    File.Copy(f, Path.Combine(fname,Path.GetFileName(f)), true);
                }

                progressBarMain.Value = 60; //show some progress

                foreach(string l in backupLocations)
                {
                    if (over)//if overriding is true, delete old identical zip files
                    {
                        try
                        { 
                        if (File.Exists(Path.Combine(l, fname + "_" + dt.Day + "-" + dt.Month + "-" + dt.Year + ".zip")))
                            File.Delete(Path.Combine(l, fname + "_" + dt.Day + "-" + dt.Month + "-" + dt.Year + ".zip"));

                        if (File.Exists(Path.Combine(l, fname + ".zip")))
                            File.Delete(Path.Combine(l, fname + ".zip"));
                        }
                        catch (Exception ex)
                        {
                            groupBoxSettings.Enabled = true; //enable controls again
                            buttonOK.Enabled = true;

                            Console.WriteLine(ex);
                            progressBarMain.Value = 0;
                            displayText(ex.Message, 3000, "red");
                            return;
                        }
                    }

                    try
                    { 
                        if (checkBoxDate.Checked)
                            ZipFile.CreateFromDirectory(fname, Path.Combine(l, fname + "_" + dt.Day + "-" + dt.Month + "-" + dt.Year+".zip"));
                        else
                            ZipFile.CreateFromDirectory(fname, Path.Combine(l, fname + ".zip"));
                    }
                    catch(Exception ex)
                    {
                        groupBoxSettings.Enabled = true; //enable controls again
                        buttonOK.Enabled = true;

                        Console.WriteLine(ex);
                        progressBarMain.Value = 0;
                        displayText(ex.Message, 3000, "red");
                        return;
                    }
                }

                Directory.Delete(fname,true);
            }

            #endregion

            groupBoxSettings.Enabled = true; //enable controls again
            buttonOK.Enabled = true;

            progressBarMain.Value = 100;
            displayText("File backup successful", 3000, "green");

        }

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

                    displayText("Successfully opened '"+ofd.FileName+"'", 1500, "green");
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
                        foreach(string s in comboBoxFilestobackup.Items)
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
    }
}
