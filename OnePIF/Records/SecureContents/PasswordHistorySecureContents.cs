using KeePassLib;
using KeePassLib.Security;
using Newtonsoft.Json;
using OnePIF.Converters;
using System;
using System.Collections.Generic;

namespace OnePIF.Records
{
    public class PasswordHistory
    {
#pragma warning disable IDE1006
        public string value { get; set; }

        [JsonConverter(typeof(UnixEpochConverter))]
        public DateTime time { get; set; }
#pragma warning restore IDE1006

        public PwEntry CreatePwEntry(PwDatabase pwDatabase)
        {
            PwEntry pwEntry = new PwEntry(true, true)
            {
                IconId = PwIcon.Key,
                CreationTime = this.time,
                LastModificationTime = this.time
            };
            pwEntry.Strings.Set(PwDefs.PasswordField, new ProtectedString(pwDatabase.MemoryProtection.ProtectPassword, this.value));

            return pwEntry;
        }
    }

    //wallet.financial.CreditCard (history field: cvv)
    //wallet.financial.BankAccountUS (history field: telephonePin)
    //wallet.computer.Database (history field: password)
    //wallet.membership.Membership (history field: pin)
    //wallet.onlineservices.Email.v2 (history field: pop_password)
    //wallet.membership.RewardProgram (history field: pin)
    //wallet.computer.UnixServer (history field: password)
    //wallet.government.SsnUS (history field: number)
    //wallet.computer.Router (history field: password)
    public class PasswordHistorySecureContents : ItemSecureContents
    {
#pragma warning disable IDE1006
        public IList<PasswordHistory> passwordHistory { get; set; }
#pragma warning restore IDE1006

        public override void PopulateEntry(PwEntry pwEntry, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            base.PopulateEntry(pwEntry, pwDatabase, userPrefs);

            if (passwordHistory != null)
            {
                foreach (PasswordHistory previousPassword in passwordHistory)
                    pwEntry.History.Add(previousPassword.CreatePwEntry(pwDatabase));
            }
        }
    }
}
