using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class CurriculumConfiguration : IEntityTypeConfiguration<Curriculum>
    {
        public void Configure(EntityTypeBuilder<Curriculum> builder)
        {
            builder.HasKey(x => x.CurriculumId);
            builder.HasIndex(x => x.CurriculumId).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(40);
            builder.Property(x => x.Description).HasMaxLength(100);
        }
    }
}
