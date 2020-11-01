using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;


namespace FileStore.Models.Documents
{
    public class DocumentUploadRequest
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public DateTime LastReviewed { get; set; }
    }
}
