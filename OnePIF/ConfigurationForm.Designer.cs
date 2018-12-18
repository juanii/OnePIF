namespace OnePIF
{
    partial class ConfigurationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.folderStructureGroupBox = new System.Windows.Forms.GroupBox();
            this.folderLayoutFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.categoryFolderLayoutRadioButton = new System.Windows.Forms.RadioButton();
            this.userFolderLayoutRadioButton = new System.Windows.Forms.RadioButton();
            this.parentFolderFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.createParentFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.dateFormatGroupBox = new System.Windows.Forms.GroupBox();
            this.dateFormatFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dateInternationalRadioButton = new System.Windows.Forms.RadioButton();
            this.dateLocaleRadioButton = new System.Windows.Forms.RadioButton();
            this.importButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.fileGroupBox = new System.Windows.Forms.GroupBox();
            this.folderStructureGroupBox.SuspendLayout();
            this.folderLayoutFlowLayoutPanel.SuspendLayout();
            this.parentFolderFlowLayoutPanel.SuspendLayout();
            this.dateFormatGroupBox.SuspendLayout();
            this.dateFormatFlowLayoutPanel.SuspendLayout();
            this.fileGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderStructureGroupBox
            // 
            this.folderStructureGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderStructureGroupBox.Controls.Add(this.folderLayoutFlowLayoutPanel);
            this.folderStructureGroupBox.Controls.Add(this.parentFolderFlowLayoutPanel);
            this.folderStructureGroupBox.Location = new System.Drawing.Point(12, 12);
            this.folderStructureGroupBox.Name = "folderStructureGroupBox";
            this.folderStructureGroupBox.Size = new System.Drawing.Size(270, 81);
            this.folderStructureGroupBox.TabIndex = 0;
            this.folderStructureGroupBox.TabStop = false;
            this.folderStructureGroupBox.Text = "Folder structure";
            // 
            // folderLayoutFlowLayoutPanel
            // 
            this.folderLayoutFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderLayoutFlowLayoutPanel.Controls.Add(this.categoryFolderLayoutRadioButton);
            this.folderLayoutFlowLayoutPanel.Controls.Add(this.userFolderLayoutRadioButton);
            this.folderLayoutFlowLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.folderLayoutFlowLayoutPanel.Name = "folderLayoutFlowLayoutPanel";
            this.folderLayoutFlowLayoutPanel.Size = new System.Drawing.Size(258, 25);
            this.folderLayoutFlowLayoutPanel.TabIndex = 3;
            // 
            // categoryFolderLayoutRadioButton
            // 
            this.categoryFolderLayoutRadioButton.AutoSize = true;
            this.categoryFolderLayoutRadioButton.Checked = true;
            this.categoryFolderLayoutRadioButton.Location = new System.Drawing.Point(3, 3);
            this.categoryFolderLayoutRadioButton.Name = "categoryFolderLayoutRadioButton";
            this.categoryFolderLayoutRadioButton.Size = new System.Drawing.Size(75, 17);
            this.categoryFolderLayoutRadioButton.TabIndex = 1;
            this.categoryFolderLayoutRadioButton.TabStop = true;
            this.categoryFolderLayoutRadioButton.Text = "Categories";
            this.toolTip.SetToolTip(this.categoryFolderLayoutRadioButton, "Group items in folders according to their kind");
            this.categoryFolderLayoutRadioButton.UseVisualStyleBackColor = true;
            // 
            // userFolderLayoutRadioButton
            // 
            this.userFolderLayoutRadioButton.AutoSize = true;
            this.userFolderLayoutRadioButton.Location = new System.Drawing.Point(84, 3);
            this.userFolderLayoutRadioButton.Name = "userFolderLayoutRadioButton";
            this.userFolderLayoutRadioButton.Size = new System.Drawing.Size(81, 17);
            this.userFolderLayoutRadioButton.TabIndex = 2;
            this.userFolderLayoutRadioButton.Text = "User folders";
            this.toolTip.SetToolTip(this.userFolderLayoutRadioButton, "Group items in user-created folders");
            this.userFolderLayoutRadioButton.UseVisualStyleBackColor = true;
            // 
            // parentFolderFlowLayoutPanel
            // 
            this.parentFolderFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parentFolderFlowLayoutPanel.Controls.Add(this.createParentFolderCheckBox);
            this.parentFolderFlowLayoutPanel.Location = new System.Drawing.Point(6, 50);
            this.parentFolderFlowLayoutPanel.Name = "parentFolderFlowLayoutPanel";
            this.parentFolderFlowLayoutPanel.Size = new System.Drawing.Size(258, 25);
            this.parentFolderFlowLayoutPanel.TabIndex = 3;
            // 
            // createParentFolderCheckBox
            // 
            this.createParentFolderCheckBox.AutoSize = true;
            this.createParentFolderCheckBox.Checked = true;
            this.createParentFolderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createParentFolderCheckBox.Location = new System.Drawing.Point(3, 3);
            this.createParentFolderCheckBox.Name = "createParentFolderCheckBox";
            this.createParentFolderCheckBox.Size = new System.Drawing.Size(213, 17);
            this.createParentFolderCheckBox.TabIndex = 0;
            this.createParentFolderCheckBox.Text = "Create a parent folder for imported items";
            this.toolTip.SetToolTip(this.createParentFolderCheckBox, "Keep trashed items, in the trash");
            this.createParentFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // dateFormatGroupBox
            // 
            this.dateFormatGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFormatGroupBox.Controls.Add(this.dateFormatFlowLayoutPanel);
            this.dateFormatGroupBox.Location = new System.Drawing.Point(12, 99);
            this.dateFormatGroupBox.Name = "dateFormatGroupBox";
            this.dateFormatGroupBox.Size = new System.Drawing.Size(270, 50);
            this.dateFormatGroupBox.TabIndex = 3;
            this.dateFormatGroupBox.TabStop = false;
            this.dateFormatGroupBox.Text = "Date format";
            // 
            // dateFormatFlowLayoutPanel
            // 
            this.dateFormatFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFormatFlowLayoutPanel.Controls.Add(this.dateInternationalRadioButton);
            this.dateFormatFlowLayoutPanel.Controls.Add(this.dateLocaleRadioButton);
            this.dateFormatFlowLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.dateFormatFlowLayoutPanel.Name = "dateFormatFlowLayoutPanel";
            this.dateFormatFlowLayoutPanel.Size = new System.Drawing.Size(258, 25);
            this.dateFormatFlowLayoutPanel.TabIndex = 3;
            // 
            // dateInternationalRadioButton
            // 
            this.dateInternationalRadioButton.AutoSize = true;
            this.dateInternationalRadioButton.Checked = true;
            this.dateInternationalRadioButton.Location = new System.Drawing.Point(3, 3);
            this.dateInternationalRadioButton.Name = "dateInternationalRadioButton";
            this.dateInternationalRadioButton.Size = new System.Drawing.Size(83, 17);
            this.dateInternationalRadioButton.TabIndex = 0;
            this.dateInternationalRadioButton.TabStop = true;
            this.dateInternationalRadioButton.Text = "International";
            this.toolTip.SetToolTip(this.dateInternationalRadioButton, "International");
            this.dateInternationalRadioButton.UseVisualStyleBackColor = true;
            // 
            // dateLocaleRadioButton
            // 
            this.dateLocaleRadioButton.AutoSize = true;
            this.dateLocaleRadioButton.Location = new System.Drawing.Point(92, 3);
            this.dateLocaleRadioButton.Name = "dateLocaleRadioButton";
            this.dateLocaleRadioButton.Size = new System.Drawing.Size(57, 17);
            this.dateLocaleRadioButton.TabIndex = 1;
            this.dateLocaleRadioButton.Text = "Locale";
            this.toolTip.SetToolTip(this.dateLocaleRadioButton, "Locale");
            this.dateLocaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.importButton.Enabled = false;
            this.importButton.Location = new System.Drawing.Point(207, 216);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(126, 216);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "1PIF files|*.1pif|All files|*.*";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextBox.Location = new System.Drawing.Point(6, 19);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(222, 20);
            this.filePathTextBox.TabIndex = 7;
            this.filePathTextBox.TextChanged += new System.EventHandler(this.filePathtextBox_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(234, 17);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(30, 23);
            this.browseButton.TabIndex = 8;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // fileGroupBox
            // 
            this.fileGroupBox.Controls.Add(this.filePathTextBox);
            this.fileGroupBox.Controls.Add(this.browseButton);
            this.fileGroupBox.Location = new System.Drawing.Point(12, 155);
            this.fileGroupBox.Name = "fileGroupBox";
            this.fileGroupBox.Size = new System.Drawing.Size(270, 50);
            this.fileGroupBox.TabIndex = 9;
            this.fileGroupBox.TabStop = false;
            this.fileGroupBox.Text = "File";
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.importButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 251);
            this.Controls.Add(this.fileGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.dateFormatGroupBox);
            this.Controls.Add(this.folderStructureGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OnePIF configuration";
            this.folderStructureGroupBox.ResumeLayout(false);
            this.folderLayoutFlowLayoutPanel.ResumeLayout(false);
            this.folderLayoutFlowLayoutPanel.PerformLayout();
            this.parentFolderFlowLayoutPanel.ResumeLayout(false);
            this.parentFolderFlowLayoutPanel.PerformLayout();
            this.dateFormatGroupBox.ResumeLayout(false);
            this.dateFormatFlowLayoutPanel.ResumeLayout(false);
            this.dateFormatFlowLayoutPanel.PerformLayout();
            this.fileGroupBox.ResumeLayout(false);
            this.fileGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox folderStructureGroupBox;
        private System.Windows.Forms.RadioButton userFolderLayoutRadioButton;
        private System.Windows.Forms.RadioButton categoryFolderLayoutRadioButton;
        private System.Windows.Forms.GroupBox dateFormatGroupBox;
        private System.Windows.Forms.RadioButton dateLocaleRadioButton;
        private System.Windows.Forms.RadioButton dateInternationalRadioButton;
        private System.Windows.Forms.FlowLayoutPanel folderLayoutFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel dateFormatFlowLayoutPanel;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.FlowLayoutPanel parentFolderFlowLayoutPanel;
        private System.Windows.Forms.CheckBox createParentFolderCheckBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox fileGroupBox;
    }
}