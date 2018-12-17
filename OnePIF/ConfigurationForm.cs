using System;
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
                if (this.folderCategoriesRadioButton.Checked)
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

        public UserPrefs GetUserPrefs()
        {
            return new UserPrefs()
            {
                FolderLayout = this.FolderLayout,
                DateFormat = this.DateFormat,
                KeepTrashedItems = this.KeepTrashedItems,
                CreateParentFolder = this.CreateParentFolder
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
    }
}
