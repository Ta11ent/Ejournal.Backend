using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class MarkConfigaration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.HasKey(x => x.MarkId);
            builder.HasIndex(x => x.MarkId).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(20);
        }
    }
}
