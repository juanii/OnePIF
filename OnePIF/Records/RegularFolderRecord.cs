using KeePassLib;
using System;
using System.Collections.Generic;

namespace OnePIF.Records
{
    public class RegularFolderRecord : BaseRecord
    {
#pragma warning disable IDE1006
        public SecureContents secureContents { get; set; }
#pragma warning restore IDE1006

        private static readonly Dictionary<ItemCategory, PwIcon> iconsByCategory = new Dictionary<ItemCategory, PwIcon>()
        {
            { ItemCategory.Unknown, PwIcon.Warning },
            { ItemCategory.Logins, PwIcon.World },
            { ItemCategory.SecureNotes, PwIcon.Note },
            { ItemCategory.CreditCards, PwIcon.Money },
            { ItemCategory.Passwords, PwIcon.Key },
            { ItemCategory.Identities, PwIcon.Identity },
            { ItemCategory.BankAccounts, PwIcon.Homebanking },
            { ItemCategory.Databases, PwIcon.Drive },
            { ItemCategory.DriverLicenses, PwIcon.Certificate },
            { ItemCategory.Memberships, PwIcon.Certificate },
            { ItemCategory.EmailAccounts, PwIcon.EMail },
            { ItemCategory.OutdoorLicenses, PwIcon.Certificate },
            { ItemCategory.RewardPrograms, PwIcon.Homebanking },
            { ItemCategory.Passports, PwIcon.Identity },
            { ItemCategory.Servers, PwIcon.NetworkServer },
            { ItemCategory.SocialSecurityNumbers, PwIcon.Identity },
            { ItemCategory.WirelessRouters, PwIcon.IRCommunication },
            { ItemCategory.SoftwareLicenses, PwIcon.Certificate },
            // Legacy
            { ItemCategory.iTunes, PwIcon.Apple },
            { ItemCategory.MySQLDatabase, PwIcon.Drive },
            { ItemCategory.FTPAccount, PwIcon.NetworkServer },
            { ItemCategory.iCloud, PwIcon.Apple },
            { ItemCategory.GenericAccount, PwIcon.Key },
            { ItemCategory.InstantMessenger, PwIcon.UserCommunication },
            { ItemCategory.InternetProvider, PwIcon.WorldComputer },
            { ItemCategory.AmazonS3, PwIcon.NetworkServer }
        };

        private static Dictionary<Guid, PwIcon> iconsByUuid = new Dictionary<Guid, PwIcon>();

        private static Dictionary<ItemCategory, RegularFolderRecord> foldersByCategory = new Dictionary<ItemCategory, RegularFolderRecord>();

        private static RegularFolderRecord unassignedFolder = null;

        private static RegularFolderRecord trashFolder = null;

        public static RegularFolderRecord UnassignedFolderRecord
        {
            get
            {
                if (unassignedFolder == null)
                {
                    DateTime now = DateTime.Now;
                    unassignedFolder = new RegularFolderRecord()
                    {
                        title = Properties.Strings.FolderName_Unassigned,
                        createdAt = now,
                        updatedAt = now,
                        typeName = RecordType.RegularFolder,
                        uuid = Guid.NewGuid()
                    };
                }

                return unassignedFolder;
            }
        }

        public static RegularFolderRecord TrashFolderRecord
        {
            get
            {
                if (trashFolder == null)
                {
                    DateTime now = DateTime.Now;
                    trashFolder = new RegularFolderRecord()
                    {
                        title = Properties.Strings.FolderName_Trash,
                        createdAt = now,
                        updatedAt = now,
                        typeName = RecordType.RegularFolder,
                        uuid = Guid.NewGuid()
                    };
                    iconsByUuid.Add(trashFolder.uuid, PwIcon.TrashBin);
                }

                return trashFolder;
            }
        }

        public static RegularFolderRecord FolderRecordForCategory(ItemCategory itemCategory)
        {
            RegularFolderRecord folderRecord;

            if (!foldersByCategory.TryGetValue(itemCategory, out folderRecord))
            {
                DateTime now = DateTime.Now;
                folderRecord = new RegularFolderRecord()
                {
                    title = Properties.Strings.ResourceManager.GetString(string.Concat("FolderName_", Enum.GetName(typeof(ItemCategory), itemCategory))),
                    createdAt = now,
                    updatedAt = now,
                    typeName = RecordType.RegularFolder,
                    uuid = Guid.NewGuid()
                };
                foldersByCategory.Add(itemCategory, folderRecord);
                iconsByUuid.Add(folderRecord.uuid, iconsByCategory[itemCategory]);
            }

            return folderRecord;
        }

        public PwGroup CreatePwGroup()
        {
            PwIcon folderIcon;

            if (!iconsByUuid.TryGetValue(this.uuid, out folderIcon))
                folderIcon = PwIcon.Folder;

            PwGroup folder = new PwGroup(true, true)
            {
                Name = this.title,
                CreationTime = this.createdAt,
                LastModificationTime = this.updatedAt,
                IconId = folderIcon,
            };

            return folder;
        }
    }
}
