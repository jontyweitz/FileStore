using FileStore.Domain.Documents;
using FileStore.Infrastructure.BlobStorage;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FileStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webhost = CreateWebHostBuilder(args).Build();
            var blobStorage = (BlobStorage)webhost.Services.GetService(typeof(IDocumentStore));
            blobStorage.Init();
            webhost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
