namespace OnePIF.Records
{
    public class SavedSearchRecord : BaseRecord
    {
#pragma warning disable IDE1006
        public SavedSearchSecureContents secureContents { get; set; }

        public SavedSearchOpenContents openContents { get; set; }
#pragma warning restore IDE1006
    }
}
