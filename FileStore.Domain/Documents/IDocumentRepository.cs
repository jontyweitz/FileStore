using System.Collections.Generic;

namespace FileStore.Domain.Documents
{
    public interface IDocumentRepository
    {
        void Add(Document document);
        Document Get(int id);
        List<Document> GetDocuments();
        void Delete(int id);
    }
}
