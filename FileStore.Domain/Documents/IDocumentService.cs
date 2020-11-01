using System.Threading.Tasks;

namespace FileStore.Domain.Documents
{
    public interface IDocumentService
    {
        Task Add(Document document);

        Task<Document> Get(int id);
    }
}
