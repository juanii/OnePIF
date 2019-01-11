using System;
using System.IO;
using System.Windows.Forms;

namespace OnePIF
{
    public partial class ConfigurationForm : Form
    {
        private bool settingTooltip = false;

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        public DateFormat DateFormat
        {
            get
            {
                if (this.dateInternationalRadioButton.Checked)
                    return DateFormat.International;
                else if (this.dateLocaleRadioButton.Checked)
                    return DateFormat.Locale;
                else
                    return DateFormat.Epoch;

            }
        }

        public FolderLayout FolderLayout
        {
            get
            {
                if (this.categoryFolderLayoutRadioButton.Checked)
                    return FolderLayout.Category;
                else
                    return FolderLayout.UserDefined;
            }
        }

        public bool KeepTrashedItems
        {
            get { return true /*this.keepTrashedItemsCheckBox.Checked*/; }
        }

        public bool CreateParentFolder
        {
            get { return this.createParentFolderCheckBox.Checked; }
        }

        public string ImportFilePath { get; private set; }

        public OTPFormat OTPFormat
        {
            get
            {
                if (this.otpKeeWebRadioButton.Checked)
                    return OTPFormat.KeeWeb;
                else if (this.otpTrayTOTPradioButton.Checked)
                    return OTPFormat.TrayTOTP;
                else
                    return OTPFormat.KeeOtp;
            }
        }

        public AddressFormat AddressFormat
        {
            get
            {
                if (this.addressCompactRadioButton.Checked)
                    return AddressFormat.Compact;
                else if (this.addressMultilineRadioButton.Checked)
                    return AddressFormat.Multiline;
                else
                    return AddressFormat.Expanded;
            }
        }

        public UserPrefs GetUserPrefs()
        {
            return new UserPrefs()
            {
                FolderLayout = this.FolderLayout,
                DateFormat = this.DateFormat,
                KeepTrashedItems = this.KeepTrashedItems,
                CreateParentFolder = this.CreateParentFolder,
                ImportFilePath = this.ImportFilePath,
                OTPFormat = this.OTPFormat,
                AddressFormat = this.AddressFormat
            };
        }

        private void toolTip_Popup(object sender, PopupEventArgs e)
        {
            if (!settingTooltip)
            {
                settingTooltip = true;

                string formattedDate = null;

                if (e.AssociatedControl == this.dateInternationalRadioButton)
                {
                    formattedDate = DateTimeFormatter.FormatDate(DateTime.Now, DateFormat.International);
                }
                else if (e.AssociatedControl == this.dateLocaleRadioButton)
                {
                    formattedDate = DateTimeFormatter.FormatDate(DateTime.Now, DateFormat.Locale);
                }
                //else if (e.AssociatedControl == this.dateEpochRadioButton)
                //{
                //    formattedDate = DateTimeFormatter.FormatDate(DateTime.UtcNow.Date, DateFormat.Epoch);
                //}

                if (!string.IsNullOrEmpty(formattedDate))
                {
                    (sender as ToolTip).SetToolTip(e.AssociatedControl, string.Concat("Today is ", formattedDate));
                }

                settingTooltip = false;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.filePathTextBox.Text = openFileDialog.FileName;
        }

        private void filePathtextBox_TextChanged(object sender, EventArgs e)
        {
            this.importButton.Enabled = !string.IsNullOrEmpty((sender as TextBox).Text);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.filePathTextBox.Text))
            {
                MessageBox.Show(string.Join(Environment.NewLine, new string[] { this.filePathTextBox.Text, "File not found." }), "Import", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.ImportFilePath = this.filePathTextBox.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
