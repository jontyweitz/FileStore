using System.Threading.Tasks;

namespace FileStore.Domain.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IDocumentStore documentStore;

        public DocumentService(IDocumentRepository documentRepository, IDocumentStore documentStore)
        {
            this.documentRepository = documentRepository;
            this.documentStore = documentStore;
        }

        public async Task Add(Document document)
        {
            try
            {
                documentRepository.Add(document);                
                await documentStore.Upload(document.Key.ToString(), document.Bytes);
            }
            catch
            {
                if (document.Id != 0)
                {
                    documentRepository.Delete(document.Id);
                }
                throw;
            }
        }

        public async Task<Document> Get(int id)
        {
            var document = documentRepository.Get(id);
            document.Bytes = await documentStore.Get(document.Key.ToString());
            return document;
        }
    }
}
