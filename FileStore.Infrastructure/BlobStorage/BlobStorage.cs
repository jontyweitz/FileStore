using Azure.Storage.Blobs;
using FileStore.Domain.Documents;
using FileStore.Domain.Settings;
using System.IO;
using System.Threading.Tasks;

namespace FileStore.Infrastructure.BlobStorage
{
    public class BlobStorage : IDocumentStore
    {
        private readonly ISettings settings;
        private const string containerName = "jonty";
        private BlobServiceClient blobServiceClient;
        private BlobContainerClient containerClient;

        public BlobStorage(ISettings settings)
        {
            this.settings = settings;
        }

        public void Init()
        {
            blobServiceClient = new BlobServiceClient(settings.AzureBlobStorageConnectionString);
            containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            containerClient.CreateIfNotExists();
        }

        public async Task<byte[]> Get(string key)
        {
            var blobClient = containerClient.GetBlobClient(key);
            var download = await blobClient.DownloadAsync();
            using (var memoryStream = new MemoryStream())
            {
                download.Value.Content.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public async Task Upload(string key, byte[] bytes)
        {
            var blobClient = containerClient.GetBlobClient(key);
            using (var stream = new MemoryStream(bytes))
            {
                await blobClient.UploadAsync(stream, true);
            }
        }
    }
}
