using KeePassLib;

namespace OnePIF.Records
{
    public class SecureNoteRecord : ItemRecord
    {
#pragma warning disable IDE1006
        public ItemSecureContents secureContents { get; set; }

        public OpenContents openContents { get; set; }
#pragma warning restore IDE1006

        protected override SecureContents GetSecureContents() { return this.secureContents; }

        protected override OpenContents GetOpenContents() { return this.openContents; }

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);
            pwEntry.IconId = PwIcon.Note;
        }
    }
}
