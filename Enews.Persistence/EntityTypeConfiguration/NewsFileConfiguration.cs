using Enews.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enews.Persistence.EntityTypeConfiguration
{
    internal class NewsFileConfiguration : IEntityTypeConfiguration<NewsFile>
    {
        public void Configure(EntityTypeBuilder<NewsFile> builder)
        {
            builder.HasKey(x => x.FileId);
            builder.HasIndex(x => x.FileId).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Path).HasMaxLength(200).IsRequired();
        }
    }
}
