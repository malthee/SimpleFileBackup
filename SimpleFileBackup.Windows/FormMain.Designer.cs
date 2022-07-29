namespace SimpleFileBackup.Windows
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonFilestobackup = new System.Windows.Forms.Button();
            this.labelFilesBackup = new System.Windows.Forms.Label();
            this.labelBackup = new System.Windows.Forms.Label();
            this.buttonBackupLocationsBrowse = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelInfotext = new System.Windows.Forms.Label();
            this.comboBoxFilestobackup = new System.Windows.Forms.ComboBox();
            this.buttonFilestobackupClear = new System.Windows.Forms.Button();
            this.buttonFilestobackupDeleteitem = new System.Windows.Forms.Button();
            this.comboBoxBackupLocations = new System.Windows.Forms.ComboBox();
            this.buttonBackupLocationsDeleteItem = new System.Windows.Forms.Button();
            this.buttonBackupLocationsClear = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCustomFilePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCustomBackupPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBackupPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.radioButtonZIP = new System.Windows.Forms.RadioButton();
            this.radioButtonFolder = new System.Windows.Forms.RadioButton();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.checkBoxDate = new System.Windows.Forms.CheckBox();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.checkBoxOverride = new System.Windows.Forms.CheckBox();
            this.buttonFolderstobackup = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelProgress = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFilestobackup
            // 
            this.buttonFilestobackup.Location = new System.Drawing.Point(376, 60);
            this.buttonFilestobackup.Name = "buttonFilestobackup";
            this.buttonFilestobackup.Size = new System.Drawing.Size(90, 20);
            this.buttonFilestobackup.TabIndex = 2;
            this.buttonFilestobackup.Text = "Select Files";
            this.buttonFilestobackup.UseVisualStyleBackColor = true;
            this.buttonFilestobackup.Click += new System.EventHandler(this.ButtonFilestobackup_Click);
            // 
            // labelFilesBackup
            // 
            this.labelFilesBackup.AutoSize = true;
            this.labelFilesBackup.Location = new System.Drawing.Point(12, 44);
            this.labelFilesBackup.Name = "labelFilesBackup";
            this.labelFilesBackup.Size = new System.Drawing.Size(80, 13);
            this.labelFilesBackup.TabIndex = 0;
            this.labelFilesBackup.Text = "Files to Backup";
            // 
            // labelBackup
            // 
            this.labelBackup.AutoSize = true;
            this.labelBackup.Location = new System.Drawing.Point(12, 135);
            this.labelBackup.Name = "labelBackup";
            this.labelBackup.Size = new System.Drawing.Size(105, 13);
            this.labelBackup.TabIndex = 6;
            this.labelBackup.Text = "Backup Destinations";
            // 
            // buttonBackupLocationsBrowse
            // 
            this.buttonBackupLocationsBrowse.Location = new System.Drawing.Point(376, 151);
            this.buttonBackupLocationsBrowse.Name = "buttonBackupLocationsBrowse";
            this.buttonBackupLocationsBrowse.Size = new System.Drawing.Size(90, 20);
            this.buttonBackupLocationsBrowse.TabIndex = 8;
            this.buttonBackupLocationsBrowse.Text = "Select Folders";
            this.buttonBackupLocationsBrowse.UseVisualStyleBackColor = true;
            this.buttonBackupLocationsBrowse.Click += new System.EventHandler(this.ButtonBackupBrowse_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(15, 360);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(448, 44);
            this.buttonOK.TabIndex = 19;
            this.buttonOK.Text = "Backup";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelInfotext
            // 
            this.labelInfotext.AutoEllipsis = true;
            this.labelInfotext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfotext.Location = new System.Drawing.Point(239, 221);
            this.labelInfotext.Name = "labelInfotext";
            this.labelInfotext.Size = new System.Drawing.Size(224, 65);
            this.labelInfotext.TabIndex = 19;
            this.labelInfotext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInfotext.Visible = false;
            // 
            // comboBoxFilestobackup
            // 
            this.comboBoxFilestobackup.FormattingEnabled = true;
            this.comboBoxFilestobackup.Location = new System.Drawing.Point(15, 61);
            this.comboBoxFilestobackup.Name = "comboBoxFilestobackup";
            this.comboBoxFilestobackup.Size = new System.Drawing.Size(355, 21);
            this.comboBoxFilestobackup.TabIndex = 1;
            this.comboBoxFilestobackup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBoxFilestobackup_KeyDown);
            // 
            // buttonFilestobackupClear
            // 
            this.buttonFilestobackupClear.Location = new System.Drawing.Point(376, 98);
            this.buttonFilestobackupClear.Name = "buttonFilestobackupClear";
            this.buttonFilestobackupClear.Size = new System.Drawing.Size(90, 20);
            this.buttonFilestobackupClear.TabIndex = 4;
            this.buttonFilestobackupClear.Text = "Clear List";
            this.buttonFilestobackupClear.UseVisualStyleBackColor = true;
            this.buttonFilestobackupClear.Click += new System.EventHandler(this.ButtonFilestobackupClear_Click);
            // 
            // buttonFilestobackupDeleteitem
            // 
            this.buttonFilestobackupDeleteitem.Location = new System.Drawing.Point(376, 117);
            this.buttonFilestobackupDeleteitem.Name = "buttonFilestobackupDeleteitem";
            this.buttonFilestobackupDeleteitem.Size = new System.Drawing.Size(90, 20);
            this.buttonFilestobackupDeleteitem.TabIndex = 5;
            this.buttonFilestobackupDeleteitem.Text = "Delete Item";
            this.buttonFilestobackupDeleteitem.UseVisualStyleBackColor = true;
            this.buttonFilestobackupDeleteitem.Click += new System.EventHandler(this.ButtonFilestobackupDeleteitem_Click);
            // 
            // comboBoxBackupLocations
            // 
            this.comboBoxBackupLocations.FormattingEnabled = true;
            this.comboBoxBackupLocations.Location = new System.Drawing.Point(15, 152);
            this.comboBoxBackupLocations.Name = "comboBoxBackupLocations";
            this.comboBoxBackupLocations.Size = new System.Drawing.Size(355, 21);
            this.comboBoxBackupLocations.TabIndex = 7;
            this.comboBoxBackupLocations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBoxBackupLocations_KeyDown);
            // 
            // buttonBackupLocationsDeleteItem
            // 
            this.buttonBackupLocationsDeleteItem.Location = new System.Drawing.Point(376, 189);
            this.buttonBackupLocationsDeleteItem.Name = "buttonBackupLocationsDeleteItem";
            this.buttonBackupLocationsDeleteItem.Size = new System.Drawing.Size(90, 20);
            this.buttonBackupLocationsDeleteItem.TabIndex = 10;
            this.buttonBackupLocationsDeleteItem.Text = "Delete Item";
            this.buttonBackupLocationsDeleteItem.UseVisualStyleBackColor = true;
            this.buttonBackupLocationsDeleteItem.Click += new System.EventHandler(this.ButtonBackupLocationsDeleteItem_Click);
            // 
            // buttonBackupLocationsClear
            // 
            this.buttonBackupLocationsClear.Location = new System.Drawing.Point(376, 170);
            this.buttonBackupLocationsClear.Name = "buttonBackupLocationsClear";
            this.buttonBackupLocationsClear.Size = new System.Drawing.Size(90, 20);
            this.buttonBackupLocationsClear.TabIndex = 9;
            this.buttonBackupLocationsClear.Text = "Clear List";
            this.buttonBackupLocationsClear.UseVisualStyleBackColor = true;
            this.buttonBackupLocationsClear.Click += new System.EventHandler(this.ButtonBackupLocationsClear_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(479, 24);
            this.menuStrip.TabIndex = 23;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDefaultsToolStripMenuItem,
            this.saveCustomFilePathsToolStripMenuItem,
            this.saveCustomBackupPathsToolStripMenuItem,
            this.openFilePathsToolStripMenuItem,
            this.openBackupPathsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveDefaultsToolStripMenuItem
            // 
            this.saveDefaultsToolStripMenuItem.Name = "saveDefaultsToolStripMenuItem";
            this.saveDefaultsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveDefaultsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.saveDefaultsToolStripMenuItem.Text = "Save Defaults";
            this.saveDefaultsToolStripMenuItem.Click += new System.EventHandler(this.SaveDefaultsToolStripMenuItem_Click);
            // 
            // saveCustomFilePathsToolStripMenuItem
            // 
            this.saveCustomFilePathsToolStripMenuItem.Name = "saveCustomFilePathsToolStripMenuItem";
            this.saveCustomFilePathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.saveCustomFilePathsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.saveCustomFilePathsToolStripMenuItem.Text = "Save Custom File Paths";
            this.saveCustomFilePathsToolStripMenuItem.Click += new System.EventHandler(this.SaveCustomFilePathsToolStripMenuItem_Click);
            // 
            // saveCustomBackupPathsToolStripMenuItem
            // 
            this.saveCustomBackupPathsToolStripMenuItem.Name = "saveCustomBackupPathsToolStripMenuItem";
            this.saveCustomBackupPathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.saveCustomBackupPathsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.saveCustomBackupPathsToolStripMenuItem.Text = "Save Custom Backup Paths";
            this.saveCustomBackupPathsToolStripMenuItem.Click += new System.EventHandler(this.SaveCustomBackupPathsToolStripMenuItem_Click);
            // 
            // openFilePathsToolStripMenuItem
            // 
            this.openFilePathsToolStripMenuItem.Name = "openFilePathsToolStripMenuItem";
            this.openFilePathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFilePathsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.openFilePathsToolStripMenuItem.Text = "Open File Paths";
            this.openFilePathsToolStripMenuItem.Click += new System.EventHandler(this.OpenPaths_Click);
            // 
            // openBackupPathsToolStripMenuItem
            // 
            this.openBackupPathsToolStripMenuItem.Name = "openBackupPathsToolStripMenuItem";
            this.openBackupPathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openBackupPathsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.openBackupPathsToolStripMenuItem.Text = "Open Backup Paths";
            this.openBackupPathsToolStripMenuItem.Click += new System.EventHandler(this.OpenPaths_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.radioButtonNormal);
            this.groupBoxSettings.Controls.Add(this.radioButtonZIP);
            this.groupBoxSettings.Controls.Add(this.radioButtonFolder);
            this.groupBoxSettings.Controls.Add(this.textBoxName);
            this.groupBoxSettings.Controls.Add(this.checkBoxDate);
            this.groupBoxSettings.Location = new System.Drawing.Point(18, 221);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(215, 133);
            this.groupBoxSettings.TabIndex = 12;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(6, 19);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(145, 17);
            this.radioButtonNormal.TabIndex = 13;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Put files in given directory";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // radioButtonZIP
            // 
            this.radioButtonZIP.AutoSize = true;
            this.radioButtonZIP.Location = new System.Drawing.Point(6, 65);
            this.radioButtonZIP.Name = "radioButtonZIP";
            this.radioButtonZIP.Size = new System.Drawing.Size(154, 17);
            this.radioButtonZIP.TabIndex = 15;
            this.radioButtonZIP.Text = "Create a .zip file in directory";
            this.radioButtonZIP.UseVisualStyleBackColor = true;
            this.radioButtonZIP.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // radioButtonFolder
            // 
            this.radioButtonFolder.AutoSize = true;
            this.radioButtonFolder.Location = new System.Drawing.Point(6, 42);
            this.radioButtonFolder.Name = "radioButtonFolder";
            this.radioButtonFolder.Size = new System.Drawing.Size(165, 17);
            this.radioButtonFolder.TabIndex = 14;
            this.radioButtonFolder.Text = "Create a subfolder in directory";
            this.radioButtonFolder.UseVisualStyleBackColor = true;
            this.radioButtonFolder.CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(6, 87);
            this.textBoxName.MaxLength = 20;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(171, 20);
            this.textBoxName.TabIndex = 16;
            this.textBoxName.Text = "Name Folder/.zip";
            this.textBoxName.Click += new System.EventHandler(this.TextBoxName_Click);
            this.textBoxName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxName_PreviewKeyDown);
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Enabled = false;
            this.checkBoxDate.Location = new System.Drawing.Point(6, 113);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(163, 17);
            this.checkBoxDate.TabIndex = 17;
            this.checkBoxDate.Text = "Add date to Folder/.zip name";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(239, 330);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(224, 24);
            this.progressBarMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarMain.TabIndex = 18;
            // 
            // checkBoxOverride
            // 
            this.checkBoxOverride.AutoSize = true;
            this.checkBoxOverride.Location = new System.Drawing.Point(15, 179);
            this.checkBoxOverride.Name = "checkBoxOverride";
            this.checkBoxOverride.Size = new System.Drawing.Size(183, 17);
            this.checkBoxOverride.TabIndex = 11;
            this.checkBoxOverride.Text = "Override identical files in directory";
            this.checkBoxOverride.UseVisualStyleBackColor = true;
            // 
            // buttonFolderstobackup
            // 
            this.buttonFolderstobackup.Location = new System.Drawing.Point(376, 79);
            this.buttonFolderstobackup.Name = "buttonFolderstobackup";
            this.buttonFolderstobackup.Size = new System.Drawing.Size(90, 20);
            this.buttonFolderstobackup.TabIndex = 3;
            this.buttonFolderstobackup.Text = "Select Folders";
            this.buttonFolderstobackup.UseVisualStyleBackColor = true;
            this.buttonFolderstobackup.Click += new System.EventHandler(this.ButtonFolderstobackup_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(15, 360);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(448, 44);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoEllipsis = true;
            this.labelProgress.Location = new System.Drawing.Point(239, 286);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(224, 37);
            this.labelProgress.TabIndex = 22;
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(479, 416);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonFolderstobackup);
            this.Controls.Add(this.checkBoxOverride);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.buttonBackupLocationsDeleteItem);
            this.Controls.Add(this.buttonBackupLocationsClear);
            this.Controls.Add(this.comboBoxBackupLocations);
            this.Controls.Add(this.buttonFilestobackupDeleteitem);
            this.Controls.Add(this.buttonFilestobackupClear);
            this.Controls.Add(this.comboBoxFilestobackup);
            this.Controls.Add(this.labelInfotext);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelBackup);
            this.Controls.Add(this.buttonBackupLocationsBrowse);
            this.Controls.Add(this.labelFilesBackup);
            this.Controls.Add(this.buttonFilestobackup);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SimpleFileBackup";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonFilestobackup;
        private System.Windows.Forms.Label labelFilesBackup;
        private System.Windows.Forms.Label labelBackup;
        private System.Windows.Forms.Button buttonBackupLocationsBrowse;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelInfotext;
        private System.Windows.Forms.ComboBox comboBoxFilestobackup;
        private System.Windows.Forms.Button buttonFilestobackupClear;
        private System.Windows.Forms.Button buttonFilestobackupDeleteitem;
        private System.Windows.Forms.ComboBox comboBoxBackupLocations;
        private System.Windows.Forms.Button buttonBackupLocationsDeleteItem;
        private System.Windows.Forms.Button buttonBackupLocationsClear;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.CheckBox checkBoxDate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.RadioButton radioButtonZIP;
        private System.Windows.Forms.RadioButton radioButtonFolder;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxOverride;
        private System.Windows.Forms.ToolStripMenuItem saveCustomFilePathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCustomBackupPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilePathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBackupPathsToolStripMenuItem;
        private System.Windows.Forms.Button buttonFolderstobackup;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ToolStripMenuItem saveDefaultsToolStripMenuItem;
    }
}