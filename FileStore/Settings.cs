using FileStore.Domain.Settings;

namespace FileStore
{
    public class Settings : ISettings
    {
        public string AzureBlobStorageConnectionString { get; set; }
    }
}
