using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(x => x.PartId);
            builder.HasIndex(x => x.PartId).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
        }
    }
}
