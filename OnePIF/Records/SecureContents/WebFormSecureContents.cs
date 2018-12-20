using KeePassLib;
using KeePassLib.Security;
using Newtonsoft.Json;
using OnePIF.Converters;
using OnePIF.Types;
using System.Collections.Generic;

namespace OnePIF.Records
{
    public class WebFormField
    {
#pragma warning disable IDE1006
        public string id { get; set; }

        public string name { get; set; }

        public string value { get; set; }

        [JsonConverter(typeof(EnumConverter<FieldDesignation>))]
        public FieldDesignation designation { get; set; }

        [JsonConverter(typeof(EnumConverter<WebFormFieldType>))]
        public WebFormFieldType type { get; set; }
#pragma warning restore IDE1006
    }

    public class WebFormSecureContents : URLListSecureContents
    {
#pragma warning disable IDE1006
        public IList<WebFormField> fields { get; set; }

        public string htmlAction { get; set; }

        public string htmlID { get; set; }

        public string htmlMethod { get; set; }

        public string htmlName { get; set; }
#pragma warning restore IDE1006

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);

            if (fields != null)
            {
                foreach (WebFormField webFormField in fields)
                {
                    string value = webFormField.value ?? string.Empty;

                    if (webFormField.designation == FieldDesignation.username)
                        pwEntry.Strings.Set(PwDefs.UserNameField, new ProtectedString(pwDatabase.MemoryProtection.ProtectUserName, value));
                    else if (webFormField.designation == FieldDesignation.password)
                        pwEntry.Strings.Set(PwDefs.PasswordField, new ProtectedString(pwDatabase.MemoryProtection.ProtectPassword, value));
                    else if (webFormField.type != WebFormFieldType.B && webFormField.type != WebFormFieldType.I) // Buttons and Submit elements are not relevant to the form
                        pwEntry.Strings.Set(string.Format("WebForm - {0}", webFormField.name), new ProtectedString((webFormField.type == Types.WebFormFieldType.P && pwDatabase.MemoryProtection.ProtectPassword) || (webFormField.type == Types.WebFormFieldType.U && pwDatabase.MemoryProtection.ProtectUrl), value));
                }
            }
        }
    }
}
