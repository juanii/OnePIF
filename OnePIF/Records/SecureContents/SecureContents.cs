using KeePassLib;

namespace OnePIF.Records
{
    //system.folder.Regular
    public class SecureContents
    {
        public virtual void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            return;
        }

        public virtual PwCustomIcon GetCustomIcon()
        {
            return null;
        }
    }
}
