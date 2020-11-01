using Microsoft.EntityFrameworkCore;
using FileStore.Domain.Documents;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileStore.DataAccess.TypeConfigurations
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(document => document.Id);
            builder.Property(document => document.Name).IsRequired();
            builder.Property(document => document.Category).IsRequired();
            builder.Property(document => document.LastReviewed).IsRequired();
        }
    }
}
