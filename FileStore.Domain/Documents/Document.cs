using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStore.Domain.Documents
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime LastReviewed { get; set; }
        public Guid Key { get; set; }

        [NotMapped]
        public byte[] Bytes { get; set; }
    }
}
