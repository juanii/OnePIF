using KeePassLib;
using System.Collections.Generic;

namespace OnePIF.Records
{
    //passwords.Password
    public class OpenContents
    {
#pragma warning disable IDE1006
        public IList<string> tags { get; set; }

        public int faveIndex { get; set; }
#pragma warning restore IDE1006

        public virtual void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            if (this.tags != null)
                pwEntry.Tags.AddRange(this.tags);

            if (this.faveIndex > 0 && !pwEntry.Tags.Contains(Properties.Strings.Tag_Favorite))
                pwEntry.Tags.Add(Properties.Strings.Tag_Favorite);
        }
    }
}
