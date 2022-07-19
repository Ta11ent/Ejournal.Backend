using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class HomeWorkConfiguration : IEntityTypeConfiguration<HomeWork>
    {
        public void Configure(EntityTypeBuilder<HomeWork> builder)
        {
            builder.HasKey(x => x.HomeWorkId);
            builder.HasIndex(x => x.HomeWorkId).IsUnique();
            builder.Property(x => x.Description).HasMaxLength(250);
        }
    }
}
