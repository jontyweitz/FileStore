using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileStore.Domain.Documents;
using FileStore.Models;
using FileStore.Models.Documents;
using Microsoft.AspNetCore.Mvc;

namespace FileStore.Controllers
{
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;
        private readonly IDocumentRepository documentRepository;

        public DocumentController(IDocumentService documentService, IDocumentRepository documentRepository)
        {
            this.documentService = documentService;
            this.documentRepository = documentRepository;
        }

        [HttpPost("upload")]
        public async Task<ActionResult> Upload(DocumentUploadRequest documentUploadRequest)
        {
            using (var ms = new MemoryStream())
            {
                documentUploadRequest.File.CopyTo(ms);
                var fileBytes = ms.ToArray();

                await documentService.Add(new Document
                {
                    Bytes = fileBytes,
                    Name = documentUploadRequest.File.FileName,
                    Category = documentUploadRequest.Category,
                    LastReviewed = documentUploadRequest.LastReviewed,
                    Key = Guid.NewGuid()
                });
            }
            return Redirect("/documents");
        }

        [HttpGet("{id}")]
        public async Task<FileContentResult> GetDocument(int id)
        {
            var document = await documentService.Get(id);
            return File(document.Bytes, "application/octet-stream", document.Name);
        }

        [HttpGet("ListDocuments")]
        public IEnumerable<DocumentModel> ListDocuments()
        {
            var documents = documentRepository.GetDocuments();
            return documents.Select(document => new DocumentModel
            {
                FileName = document.Name,
                Category = document.Category,
                Id = document.Id,
                LastReviewed = document.LastReviewed
            });
        }
    }
}
