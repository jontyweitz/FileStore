using System.Threading.Tasks;

namespace FileStore.Domain.Documents
{
    public interface IDocumentStore
    {
        Task<byte[]> Get(string key);
        Task Upload(string key, byte[] bytes);
    }
}
