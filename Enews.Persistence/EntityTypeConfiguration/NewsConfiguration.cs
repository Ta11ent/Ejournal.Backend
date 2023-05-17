using Enews.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enews.Persistence.EntityTypeConfiguration
{
    internal class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.NewsId);
            builder.HasIndex(x => x.NewsId).IsUnique();
            builder.Property(x => x.HeadLine).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.DateCreation).IsRequired();
        }
    }
}
