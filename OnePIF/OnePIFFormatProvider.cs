using KeePass.DataExchange;
using KeePassLib;
using KeePassLib.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OnePIF
{
    public enum ItemCategory
    {
        Unknown,
        Logins,
        SecureNotes,
        CreditCards,
        Passwords,
        Identities,
        BankAccounts,
        Databases,
        DriverLicenses,
        Memberships,
        EmailAccounts,
        OutdoorLicenses,
        RewardPrograms,
        Passports,
        Servers,
        SocialSecurityNumbers,
        WirelessRouters,
        SoftwareLicenses
    }

    public class OnePIFFormatProvider : FileFormatProvider
    {
        private readonly OnePIFParser onePIFParser = new OnePIFParser();
        private readonly OnePIFImporter onePIFImporter = new OnePIFImporter();

        public override bool SupportsImport
        {
            get { return true; }
        }

        public override bool SupportsExport
        {
            get { return false; }
        }

        public override string FormatName
        {
            get { return "1Password Interchange Format"; }
        }

        public override string ApplicationGroup
        {
            get { return KeePass.Resources.KPRes.PasswordManagers; }
        }

        public override string DefaultExtension
        {
            get { return "1pif"; }
        }

        public override bool ImportAppendsToRootGroupOnly
        {
            get { return false; }
        }

        public override bool RequiresFile
        {
            get { return true; }
        }

        public override Image SmallIcon
        {
            get { return Properties.Icons.OnePIF_icon_16; }
        }

        public override void Import(PwDatabase pwDatabase, Stream input, IStatusLogger statusLogger)
        {
            ConfigurationForm configurationForm = new ConfigurationForm();

            statusLogger.StartLogging("1PIF file import", true);

            if (configurationForm.ShowDialog() == DialogResult.OK)
            {
                statusLogger.SetText("Parsing 1PIF file...", LogStatusType.Info);
                List<Records.BaseRecord> records = onePIFParser.Parse(input);
                statusLogger.SetText(string.Format("Importing {0} parsed records...", records.Count), LogStatusType.Info);
                onePIFImporter.Import(records, pwDatabase, statusLogger, configurationForm.GetUserPrefs());
                statusLogger.SetText("Finished import.", LogStatusType.Info);
            }
            else
            {
                statusLogger.SetText("Import cancelled.", LogStatusType.Info);
            }

            statusLogger.EndLogging();
        }
    }
}
