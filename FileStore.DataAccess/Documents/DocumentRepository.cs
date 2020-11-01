using FileStore.Domain.Documents;
using System.Collections.Generic;
using System.Linq;

namespace FileStore.DataAccess.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly FileStoreDbContext dbContext;

        public DocumentRepository(FileStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Document document)
        {
            dbContext.Documents.Add(document);
            dbContext.SaveChanges();
        }

        public List<Document> GetDocuments()
        {
            return dbContext.Documents.ToList();
        }

        public Document Get(int id)
        {
            return dbContext.Documents.Find(id);
        }

        public void Delete(int id)
        {
            var document = new Document { Id = id };
            dbContext.Documents.Attach(document);
            dbContext.Documents.Remove(document);
            dbContext.SaveChanges();
        }
    }
}
