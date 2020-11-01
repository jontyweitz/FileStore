namespace FileStore.Domain.Settings
{
    public interface ISettings
    {
        string AzureBlobStorageConnectionString { get; }
    }
}
