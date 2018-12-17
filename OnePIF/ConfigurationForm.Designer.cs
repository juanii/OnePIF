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
            this.folderGroupBox = new System.Windows.Forms.GroupBox();
            this.folderFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.folderCategoriesRadioButton = new System.Windows.Forms.RadioButton();
            this.folderUserRadioButton = new System.Windows.Forms.RadioButton();
            this.dateGroupBox = new System.Windows.Forms.GroupBox();
            this.dateFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dateInternationalRadioButton = new System.Windows.Forms.RadioButton();
            this.dateLocaleRadioButton = new System.Windows.Forms.RadioButton();
            this.importButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.createParentFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.folderGroupBox.SuspendLayout();
            this.folderFlowLayoutPanel.SuspendLayout();
            this.dateGroupBox.SuspendLayout();
            this.dateFlowLayoutPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderGroupBox
            // 
            this.folderGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderGroupBox.Controls.Add(this.folderFlowLayoutPanel);
            this.folderGroupBox.Controls.Add(this.flowLayoutPanel3);
            this.folderGroupBox.Location = new System.Drawing.Point(12, 12);
            this.folderGroupBox.Name = "folderGroupBox";
            this.folderGroupBox.Size = new System.Drawing.Size(270, 81);
            this.folderGroupBox.TabIndex = 0;
            this.folderGroupBox.TabStop = false;
            this.folderGroupBox.Text = "Folder structure";
            // 
            // folderFlowLayoutPanel
            // 
            this.folderFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderFlowLayoutPanel.Controls.Add(this.folderCategoriesRadioButton);
            this.folderFlowLayoutPanel.Controls.Add(this.folderUserRadioButton);
            this.folderFlowLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.folderFlowLayoutPanel.Name = "folderFlowLayoutPanel";
            this.folderFlowLayoutPanel.Size = new System.Drawing.Size(258, 25);
            this.folderFlowLayoutPanel.TabIndex = 3;
            // 
            // folderCategoriesRadioButton
            // 
            this.folderCategoriesRadioButton.AutoSize = true;
            this.folderCategoriesRadioButton.Checked = true;
            this.folderCategoriesRadioButton.Location = new System.Drawing.Point(3, 3);
            this.folderCategoriesRadioButton.Name = "folderCategoriesRadioButton";
            this.folderCategoriesRadioButton.Size = new System.Drawing.Size(75, 17);
            this.folderCategoriesRadioButton.TabIndex = 1;
            this.folderCategoriesRadioButton.TabStop = true;
            this.folderCategoriesRadioButton.Text = "Categories";
            this.toolTip.SetToolTip(this.folderCategoriesRadioButton, "Group items in folders according to their kind");
            this.folderCategoriesRadioButton.UseVisualStyleBackColor = true;
            // 
            // folderUserRadioButton
            // 
            this.folderUserRadioButton.AutoSize = true;
            this.folderUserRadioButton.Location = new System.Drawing.Point(84, 3);
            this.folderUserRadioButton.Name = "folderUserRadioButton";
            this.folderUserRadioButton.Size = new System.Drawing.Size(81, 17);
            this.folderUserRadioButton.TabIndex = 2;
            this.folderUserRadioButton.Text = "User folders";
            this.toolTip.SetToolTip(this.folderUserRadioButton, "Group items in user-created folders");
            this.folderUserRadioButton.UseVisualStyleBackColor = true;
            // 
            // dateGroupBox
            // 
            this.dateGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateGroupBox.Controls.Add(this.dateFlowLayoutPanel);
            this.dateGroupBox.Location = new System.Drawing.Point(12, 99);
            this.dateGroupBox.Name = "dateGroupBox";
            this.dateGroupBox.Size = new System.Drawing.Size(270, 50);
            this.dateGroupBox.TabIndex = 3;
            this.dateGroupBox.TabStop = false;
            this.dateGroupBox.Text = "Date format";
            // 
            // dateFlowLayoutPanel
            // 
            this.dateFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateFlowLayoutPanel.Controls.Add(this.dateInternationalRadioButton);
            this.dateFlowLayoutPanel.Controls.Add(this.dateLocaleRadioButton);
            this.dateFlowLayoutPanel.Location = new System.Drawing.Point(6, 19);
            this.dateFlowLayoutPanel.Name = "dateFlowLayoutPanel";
            this.dateFlowLayoutPanel.Size = new System.Drawing.Size(258, 25);
            this.dateFlowLayoutPanel.TabIndex = 3;
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
            this.importButton.Location = new System.Drawing.Point(207, 158);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 5;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(126, 158);
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
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.createParentFolderCheckBox);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(6, 50);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(258, 25);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.importButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 193);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.dateGroupBox);
            this.Controls.Add(this.folderGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OnePIF configuration";
            this.folderGroupBox.ResumeLayout(false);
            this.folderFlowLayoutPanel.ResumeLayout(false);
            this.folderFlowLayoutPanel.PerformLayout();
            this.dateGroupBox.ResumeLayout(false);
            this.dateFlowLayoutPanel.ResumeLayout(false);
            this.dateFlowLayoutPanel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox folderGroupBox;
        private System.Windows.Forms.RadioButton folderUserRadioButton;
        private System.Windows.Forms.RadioButton folderCategoriesRadioButton;
        private System.Windows.Forms.GroupBox dateGroupBox;
        private System.Windows.Forms.RadioButton dateLocaleRadioButton;
        private System.Windows.Forms.RadioButton dateInternationalRadioButton;
        private System.Windows.Forms.FlowLayoutPanel folderFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel dateFlowLayoutPanel;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.CheckBox createParentFolderCheckBox;
    }
}