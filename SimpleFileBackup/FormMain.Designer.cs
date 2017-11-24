namespace SimpleFileBackup
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
            this.saveDefaultFilePathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDefaultBackupPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFilestobackup
            // 
            this.buttonFilestobackup.Location = new System.Drawing.Point(376, 60);
            this.buttonFilestobackup.Name = "buttonFilestobackup";
            this.buttonFilestobackup.Size = new System.Drawing.Size(75, 20);
            this.buttonFilestobackup.TabIndex = 1;
            this.buttonFilestobackup.Text = "Browse";
            this.buttonFilestobackup.UseVisualStyleBackColor = true;
            this.buttonFilestobackup.Click += new System.EventHandler(this.buttonFilestobackup_Click);
            // 
            // labelFilesBackup
            // 
            this.labelFilesBackup.AutoSize = true;
            this.labelFilesBackup.Location = new System.Drawing.Point(12, 44);
            this.labelFilesBackup.Name = "labelFilesBackup";
            this.labelFilesBackup.Size = new System.Drawing.Size(80, 13);
            this.labelFilesBackup.TabIndex = 2;
            this.labelFilesBackup.Text = "Files to Backup";
            // 
            // labelBackup
            // 
            this.labelBackup.AutoSize = true;
            this.labelBackup.Location = new System.Drawing.Point(12, 117);
            this.labelBackup.Name = "labelBackup";
            this.labelBackup.Size = new System.Drawing.Size(105, 13);
            this.labelBackup.TabIndex = 5;
            this.labelBackup.Text = "Backup Destinations";
            // 
            // buttonBackupLocationsBrowse
            // 
            this.buttonBackupLocationsBrowse.Location = new System.Drawing.Point(376, 133);
            this.buttonBackupLocationsBrowse.Name = "buttonBackupLocationsBrowse";
            this.buttonBackupLocationsBrowse.Size = new System.Drawing.Size(75, 20);
            this.buttonBackupLocationsBrowse.TabIndex = 4;
            this.buttonBackupLocationsBrowse.Text = "Browse";
            this.buttonBackupLocationsBrowse.UseVisualStyleBackColor = true;
            this.buttonBackupLocationsBrowse.Click += new System.EventHandler(this.buttonBackupBrowse_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(15, 342);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(436, 44);
            this.buttonOK.TabIndex = 18;
            this.buttonOK.Text = "Backup";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelInfotext
            // 
            this.labelInfotext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfotext.Location = new System.Drawing.Point(239, 203);
            this.labelInfotext.Name = "labelInfotext";
            this.labelInfotext.Size = new System.Drawing.Size(207, 107);
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
            this.comboBoxFilestobackup.TabIndex = 0;
            this.comboBoxFilestobackup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxFilestobackup_KeyDown);
            // 
            // buttonFilestobackupClear
            // 
            this.buttonFilestobackupClear.Location = new System.Drawing.Point(376, 78);
            this.buttonFilestobackupClear.Name = "buttonFilestobackupClear";
            this.buttonFilestobackupClear.Size = new System.Drawing.Size(75, 20);
            this.buttonFilestobackupClear.TabIndex = 2;
            this.buttonFilestobackupClear.Text = "Clear List";
            this.buttonFilestobackupClear.UseVisualStyleBackColor = true;
            this.buttonFilestobackupClear.Click += new System.EventHandler(this.buttonFilestobackupClear_Click);
            // 
            // buttonFilestobackupDeleteitem
            // 
            this.buttonFilestobackupDeleteitem.Location = new System.Drawing.Point(376, 96);
            this.buttonFilestobackupDeleteitem.Name = "buttonFilestobackupDeleteitem";
            this.buttonFilestobackupDeleteitem.Size = new System.Drawing.Size(75, 20);
            this.buttonFilestobackupDeleteitem.TabIndex = 3;
            this.buttonFilestobackupDeleteitem.Text = "Delete Item";
            this.buttonFilestobackupDeleteitem.UseVisualStyleBackColor = true;
            this.buttonFilestobackupDeleteitem.Click += new System.EventHandler(this.buttonFilestobackupDeleteitem_Click);
            // 
            // comboBoxBackupLocations
            // 
            this.comboBoxBackupLocations.FormattingEnabled = true;
            this.comboBoxBackupLocations.Location = new System.Drawing.Point(15, 134);
            this.comboBoxBackupLocations.Name = "comboBoxBackupLocations";
            this.comboBoxBackupLocations.Size = new System.Drawing.Size(355, 21);
            this.comboBoxBackupLocations.TabIndex = 20;
            this.comboBoxBackupLocations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxBackupLocations_KeyDown);
            // 
            // buttonBackupLocationsDeleteItem
            // 
            this.buttonBackupLocationsDeleteItem.Location = new System.Drawing.Point(376, 168);
            this.buttonBackupLocationsDeleteItem.Name = "buttonBackupLocationsDeleteItem";
            this.buttonBackupLocationsDeleteItem.Size = new System.Drawing.Size(75, 20);
            this.buttonBackupLocationsDeleteItem.TabIndex = 22;
            this.buttonBackupLocationsDeleteItem.Text = "Delete Item";
            this.buttonBackupLocationsDeleteItem.UseVisualStyleBackColor = true;
            this.buttonBackupLocationsDeleteItem.Click += new System.EventHandler(this.buttonBackupLocationsDeleteItem_Click);
            // 
            // buttonBackupLocationsClear
            // 
            this.buttonBackupLocationsClear.Location = new System.Drawing.Point(376, 150);
            this.buttonBackupLocationsClear.Name = "buttonBackupLocationsClear";
            this.buttonBackupLocationsClear.Size = new System.Drawing.Size(75, 20);
            this.buttonBackupLocationsClear.TabIndex = 21;
            this.buttonBackupLocationsClear.Text = "Clear List";
            this.buttonBackupLocationsClear.UseVisualStyleBackColor = true;
            this.buttonBackupLocationsClear.Click += new System.EventHandler(this.buttonBackupLocationsClear_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(460, 24);
            this.menuStrip.TabIndex = 23;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDefaultFilePathsToolStripMenuItem,
            this.saveDefaultBackupPathsToolStripMenuItem,
            this.saveCustomFilePathsToolStripMenuItem,
            this.saveCustomBackupPathsToolStripMenuItem,
            this.openFilePathsToolStripMenuItem,
            this.openBackupPathsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveDefaultFilePathsToolStripMenuItem
            // 
            this.saveDefaultFilePathsToolStripMenuItem.Name = "saveDefaultFilePathsToolStripMenuItem";
            this.saveDefaultFilePathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.saveDefaultFilePathsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.saveDefaultFilePathsToolStripMenuItem.Text = "Save Default File Paths";
            this.saveDefaultFilePathsToolStripMenuItem.Click += new System.EventHandler(this.saveDefaultFilePathsToolStripMenuItem_Click);
            // 
            // saveDefaultBackupPathsToolStripMenuItem
            // 
            this.saveDefaultBackupPathsToolStripMenuItem.Name = "saveDefaultBackupPathsToolStripMenuItem";
            this.saveDefaultBackupPathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.saveDefaultBackupPathsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.saveDefaultBackupPathsToolStripMenuItem.Text = "Save Default Backup Paths";
            this.saveDefaultBackupPathsToolStripMenuItem.Click += new System.EventHandler(this.saveDefaultBackupPathsToolStripMenuItem_Click);
            // 
            // saveCustomFilePathsToolStripMenuItem
            // 
            this.saveCustomFilePathsToolStripMenuItem.Name = "saveCustomFilePathsToolStripMenuItem";
            this.saveCustomFilePathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.saveCustomFilePathsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.saveCustomFilePathsToolStripMenuItem.Text = "Save Custom File Paths";
            this.saveCustomFilePathsToolStripMenuItem.Click += new System.EventHandler(this.saveCustomFilePathsToolStripMenuItem_Click);
            // 
            // saveCustomBackupPathsToolStripMenuItem
            // 
            this.saveCustomBackupPathsToolStripMenuItem.Name = "saveCustomBackupPathsToolStripMenuItem";
            this.saveCustomBackupPathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.saveCustomBackupPathsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.saveCustomBackupPathsToolStripMenuItem.Text = "Save Custom Backup Paths";
            this.saveCustomBackupPathsToolStripMenuItem.Click += new System.EventHandler(this.saveCustomBackupPathsToolStripMenuItem_Click);
            // 
            // openFilePathsToolStripMenuItem
            // 
            this.openFilePathsToolStripMenuItem.Name = "openFilePathsToolStripMenuItem";
            this.openFilePathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFilePathsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.openFilePathsToolStripMenuItem.Text = "Open File Paths";
            this.openFilePathsToolStripMenuItem.Click += new System.EventHandler(this.openFilePathsToolStripMenuItem_Click);
            // 
            // openBackupPathsToolStripMenuItem
            // 
            this.openBackupPathsToolStripMenuItem.Name = "openBackupPathsToolStripMenuItem";
            this.openBackupPathsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openBackupPathsToolStripMenuItem.Size = new System.Drawing.Size(286, 22);
            this.openBackupPathsToolStripMenuItem.Text = "Open Backup Paths";
            this.openBackupPathsToolStripMenuItem.Click += new System.EventHandler(this.openBackupPathsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.radioButtonNormal);
            this.groupBoxSettings.Controls.Add(this.radioButtonZIP);
            this.groupBoxSettings.Controls.Add(this.radioButtonFolder);
            this.groupBoxSettings.Controls.Add(this.textBoxName);
            this.groupBoxSettings.Controls.Add(this.checkBoxDate);
            this.groupBoxSettings.Location = new System.Drawing.Point(18, 203);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(215, 133);
            this.groupBoxSettings.TabIndex = 24;
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
            this.radioButtonNormal.TabIndex = 5;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Put files in given directory";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonZIP
            // 
            this.radioButtonZIP.AutoSize = true;
            this.radioButtonZIP.Location = new System.Drawing.Point(6, 65);
            this.radioButtonZIP.Name = "radioButtonZIP";
            this.radioButtonZIP.Size = new System.Drawing.Size(154, 17);
            this.radioButtonZIP.TabIndex = 4;
            this.radioButtonZIP.Text = "Create a .zip file in directory";
            this.radioButtonZIP.UseVisualStyleBackColor = true;
            this.radioButtonZIP.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButtonFolder
            // 
            this.radioButtonFolder.AutoSize = true;
            this.radioButtonFolder.Location = new System.Drawing.Point(6, 42);
            this.radioButtonFolder.Name = "radioButtonFolder";
            this.radioButtonFolder.Size = new System.Drawing.Size(165, 17);
            this.radioButtonFolder.TabIndex = 3;
            this.radioButtonFolder.Text = "Create a subfolder in directory";
            this.radioButtonFolder.UseVisualStyleBackColor = true;
            this.radioButtonFolder.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(6, 87);
            this.textBoxName.MaxLength = 20;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(171, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Text = "Name Folder/.zip";
            this.textBoxName.Click += new System.EventHandler(this.textBoxName_Click);
            this.textBoxName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxName_PreviewKeyDown);
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Enabled = false;
            this.checkBoxDate.Location = new System.Drawing.Point(6, 113);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(163, 17);
            this.checkBoxDate.TabIndex = 1;
            this.checkBoxDate.Text = "Add date to Folder/.zip name";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(239, 313);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(212, 23);
            this.progressBarMain.TabIndex = 25;
            // 
            // checkBoxOverride
            // 
            this.checkBoxOverride.AutoSize = true;
            this.checkBoxOverride.Location = new System.Drawing.Point(15, 161);
            this.checkBoxOverride.Name = "checkBoxOverride";
            this.checkBoxOverride.Size = new System.Drawing.Size(183, 17);
            this.checkBoxOverride.TabIndex = 26;
            this.checkBoxOverride.Text = "Override identical files in directory";
            this.checkBoxOverride.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(460, 398);
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
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "SimpleFileBackup v1.01";
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
        private System.Windows.Forms.ToolStripMenuItem saveDefaultFilePathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDefaultBackupPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCustomFilePathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCustomBackupPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilePathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBackupPathsToolStripMenuItem;
    }
}