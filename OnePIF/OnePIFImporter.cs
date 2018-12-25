using KeePassLib;
using KeePassLib.Interfaces;
using System;
using System.Collections.Generic;

namespace OnePIF
{
    public class OnePIFImporter
    {
        private static readonly Dictionary<Records.RecordType, ItemCategory> categoriesByRecordType = new Dictionary<Records.RecordType, ItemCategory>()
        {
            { Records.RecordType.WebForm, ItemCategory.Logins },
            { Records.RecordType.SecureNote, ItemCategory.SecureNotes },
            { Records.RecordType.CreditCard, ItemCategory.CreditCards },
            { Records.RecordType.Password, ItemCategory.Passwords },
            { Records.RecordType.Identity, ItemCategory.Identities },
            { Records.RecordType.BankAccountUS, ItemCategory.BankAccounts },
            { Records.RecordType.Database, ItemCategory.Databases },
            { Records.RecordType.DriversLicense, ItemCategory.DriverLicenses },
            { Records.RecordType.Membership, ItemCategory.Memberships },
            { Records.RecordType.EmailV2, ItemCategory.EmailAccounts },
            { Records.RecordType.HuntingLicense, ItemCategory.OutdoorLicenses },
            { Records.RecordType.RewardProgram, ItemCategory.RewardPrograms },
            { Records.RecordType.Passport, ItemCategory.Passports },
            { Records.RecordType.UnixServer, ItemCategory.Servers },
            { Records.RecordType.SsnUS, ItemCategory.SocialSecurityNumbers },
            { Records.RecordType.Router, ItemCategory.WirelessRouters },
            { Records.RecordType.License, ItemCategory.SoftwareLicenses }
        };

        public void Import(List<Records.BaseRecord> records, PwDatabase pwDatabase, IStatusLogger statusLogger, UserPrefs userPrefs)
        {
            List<Records.ItemRecord> trashedRecords = null;

            records.RemoveAll(record => record is Records.SavedSearchRecord);

            // Copy trashed items to another collection
            if (userPrefs.KeepTrashedItems)
                trashedRecords = records.FindAll(record => (record is Records.ItemRecord) && (record as Records.ItemRecord).trashed).ConvertAll<Records.ItemRecord>(record => record as Records.ItemRecord);

            // Filter out trashed items from main set
            records.RemoveAll(record => (record is Records.ItemRecord) && (record as Records.ItemRecord).trashed);

            if (userPrefs.FolderLayout == FolderLayout.Category)
            {
                // Since they're not being used, filter out user-defined folders from main set
                records = records.FindAll(record => record is Records.ItemRecord);

                // Assign parent folder to items according to their category
                foreach (Records.ItemRecord itemRecord in records.ConvertAll(record => record as Records.ItemRecord))
                {
                    ItemCategory itemCategory = ItemCategory.Unknown;

                    if (!categoriesByRecordType.TryGetValue(itemRecord.typeName, out itemCategory))
                        itemCategory = ItemCategory.Unknown;

                    Records.RegularFolderRecord categoryFolder = Records.RegularFolderRecord.FolderRecordForCategory(itemCategory);

                    if (!records.Contains(categoryFolder))
                        records.Add(categoryFolder);

                    itemRecord.folderUuid = categoryFolder.uuid;
                }
            }
            else if (userPrefs.FolderLayout == FolderLayout.UserDefined)
            {
                Records.RegularFolderRecord unassignedFolder = null;

                // Assign orphan items the "Unassigned" folder as parent
                foreach (Records.ItemRecord itemRecord in records.FindAll(record => (record is Records.ItemRecord) && Guid.Empty.Equals((record as Records.ItemRecord).folderUuid)))
                {
                    if (unassignedFolder == null)
                    {
                        unassignedFolder = Records.RegularFolderRecord.UnassignedFolderRecord;
                        records.Add(unassignedFolder);
                    }

                    itemRecord.folderUuid = Records.RegularFolderRecord.UnassignedFolderRecord.uuid;
                }
            }

            IEnumerable<TreeNode<Records.BaseRecord>> tree = buildTree(records);

            PwGroup rootGroup = null;

            if (userPrefs.CreateParentFolder)
                rootGroup = new PwGroup(true, true) { Name = "1Password Import on " + DateTimeFormatter.FormatDateTime(DateTime.Now, userPrefs.DateFormat) };
            else
                rootGroup = pwDatabase.RootGroup;

            foreach (TreeNode<Records.BaseRecord> node in tree)
                importRecord(node, rootGroup, pwDatabase, userPrefs);

            if (trashedRecords != null && trashedRecords.Count > 0)
            {
                PwGroup trashGroup = Records.RegularFolderRecord.TrashFolderRecord.CreatePwGroup();

                foreach (Records.ItemRecord trashedRecord in trashedRecords)
                {
                    PwEntry entry = trashedRecord.CreatePwEntry(pwDatabase, userPrefs);
                    trashGroup.AddEntry(entry, true);
                }

                rootGroup.AddGroup(trashGroup, true);
            }

            if (userPrefs.CreateParentFolder)
                pwDatabase.RootGroup.AddGroup(rootGroup, true);
        }

        private void importRecord(TreeNode<Records.BaseRecord> currentNode, PwGroup pwGroupAddTo, PwDatabase pwDatabase, UserPrefs userPrefs)
        {
            Records.BaseRecord record = currentNode.AssociatedObject;

            if (record is Records.RegularFolderRecord)
            {
                PwGroup folder = (record as Records.RegularFolderRecord).CreatePwGroup();

                if (folder != null)
                {
                    pwGroupAddTo.AddGroup(folder, true);

                    foreach (TreeNode<Records.BaseRecord> child in currentNode.Children)
                        importRecord(child, folder, pwDatabase, userPrefs);
                }
            }
            else
            {
                Records.ItemRecord itemRecord = record as Records.ItemRecord;

                PwEntry entry = itemRecord.CreatePwEntry(pwDatabase, userPrefs);

                if (entry != null)
                {
                    PwCustomIcon customIcon = itemRecord.GetPwCustomIcon();

                    if (customIcon != null)
                    {
                        if (!pwDatabase.CustomIcons.Exists(icon => icon.Uuid.Equals(customIcon.Uuid)))
                            pwDatabase.CustomIcons.Add(customIcon);

                        pwDatabase.UINeedsIconUpdate = true;
                    }

                    pwGroupAddTo.AddEntry(entry, true);
                }
            }
        }

        private IEnumerable<TreeNode<Records.BaseRecord>> buildTree(List<Records.BaseRecord> records)
        {
            Dictionary<Guid, TreeNode<Records.BaseRecord>> lookUp = new Dictionary<Guid, TreeNode<Records.BaseRecord>>();
            records.ForEach(x => lookUp.Add(x.uuid, new TreeNode<Records.BaseRecord>() { AssociatedObject = x }));

            foreach (TreeNode<Records.BaseRecord> node in lookUp.Values)
            {
                TreeNode<Records.BaseRecord> parent;

                if (lookUp.TryGetValue(node.AssociatedObject.folderUuid, out parent))
                {
                    node.Parent = parent;
                    parent.Children.Add(node);
                }
            }

            List<TreeNode<Records.BaseRecord>> rootNodes = new List<TreeNode<Records.BaseRecord>>();

            foreach (var value in lookUp.Values)
            {
                if (value.Parent == null)
                    rootNodes.Add(value);
            }

            return rootNodes;
        }
    }
}
