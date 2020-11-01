using FileContextCore;
using FileContextCore.FileManager;
using FileContextCore.Serializer;
using FileStore.DataAccess.TypeConfigurations;
using FileStore.Domain.Documents;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FileStore.DataAccess
{
    public class FileStoreDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DocumentTypeConfiguration)));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseFileContextDatabase<JSONSerializer, DefaultFileManager>();
        }
    }
}
