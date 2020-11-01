using System;

namespace FileStore.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public DateTime LastReviewed { get; set; }
        public string FileName { get; set; }
    }
}
