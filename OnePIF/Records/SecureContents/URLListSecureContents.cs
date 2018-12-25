using KeePassLib;
using KeePassLib.Security;
using System.Collections.Generic;

namespace OnePIF.Records
{
    public class URL
    {
#pragma warning disable IDE1006
        public string label { get; set; }

        public string url { get; set; }
#pragma warning restore IDE1006
    }

    //passwords.Password (history field: password)
    //webforms.WebForm (history field: password)
    public class URLListSecureContents : PasswordHistorySecureContents
    {
#pragma warning disable IDE1006
        public IList<URL> URLs { get; set; }
#pragma warning restore IDE1006

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);

            if (this.URLs != null)
            {
                int i = 1;

                string mainURLString = null;

                if (pwEntry.Strings.Exists(PwDefs.UrlField))
                    mainURLString = pwEntry.Strings.Get(PwDefs.UrlField).ReadString();

                foreach (URL url in this.URLs)
                {
                    if (url.url.Equals(mainURLString))
                        continue;

                    string urlLabel = url.label;

                    if (string.IsNullOrEmpty(url.label))
                        urlLabel = string.Format("URL {0}", i++);

                    pwEntry.Strings.Set(urlLabel, new ProtectedString(pwDatabase.MemoryProtection.ProtectUrl, url.url));
                }
            }
        }
    }
}
