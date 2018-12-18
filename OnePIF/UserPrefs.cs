namespace OnePIF
{
    public enum FolderLayout
    {
        Flat,
        Category,
        UserDefined
    }

    public enum DateFormat
    {
        International,
        Locale,
        Epoch
    }

    public class UserPrefs
    {
        public FolderLayout FolderLayout { get; set; }

        public DateFormat DateFormat { get; set; }

        public bool KeepTrashedItems { get; set; }

        public bool CreateParentFolder { get; set; }

        public string ImportFilePath { get; set; }
    }
}
