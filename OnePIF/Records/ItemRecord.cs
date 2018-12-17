using KeePassLib;
using System;
using System.Collections;
using System.Collections.Generic;

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

            return pwEntry;
        }

        public virtual PwCustomIcon GetPwCustomIcon()
        {
            PwCustomIcon pwCustomIcon = null;

            SecureContents secureContents = this.GetSecureContents();
            if (secureContents != null)
                pwCustomIcon = secureContents.GetCustomIcon();

            return pwCustomIcon;
        }
    }
}
