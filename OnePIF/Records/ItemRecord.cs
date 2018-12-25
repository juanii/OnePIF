using KeePassLib;
using KeePassLib.Security;
using System.IO;

namespace OnePIF.Records
{
    public class ItemRecord : BaseRecord
    {
#pragma warning disable IDE1006
        public int faveIndex { get; set; }

        public bool trashed { get; set; }
#pragma warning restore IDE1006

        protected virtual SecureContents GetSecureContents() { return null; }

        protected virtual OpenContents GetOpenContents() { return null; }

        public override PwEntry CreatePwEntry(PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            PwEntry pwEntry = base.CreatePwEntry(pwDatabase, userPrefs);

            SecureContents secureContents = this.GetSecureContents();
            if (secureContents != null)
                secureContents.PopulateEntry(pwEntry, pwDatabase, userPrefs);

            OpenContents openContents = this.GetOpenContents();
            if (openContents != null)
                openContents.PopulateEntry(pwEntry, pwDatabase, userPrefs);

            if (this.faveIndex > 0 && !pwEntry.Tags.Contains(Properties.Strings.Tag_Favorite))
                pwEntry.Tags.Add(Properties.Strings.Tag_Favorite);

            string attachmentsPath = Path.Combine(Path.GetDirectoryName(userPrefs.ImportFilePath), "attachments");
            string itemAttachmentsPath = Path.Combine(attachmentsPath, this.uuid.ToString("N").ToUpper());

            if (Directory.Exists(itemAttachmentsPath))
            {
                foreach (string itemAttachmentPath in Directory.GetFiles(itemAttachmentsPath))
                    pwEntry.Binaries.Set(Path.GetFileName(itemAttachmentPath), new ProtectedBinary(false, File.ReadAllBytes(itemAttachmentPath)));
            }

            return pwEntry;
        }

        public virtual PwCustomIcon GetPwCustomIcon()
        {
            ItemSecureContents itemSecureContents = this.GetSecureContents() as ItemSecureContents;

            if (itemSecureContents != null)
                return itemSecureContents.PwCustomIcon;

            return null;
        }
    }
}
