using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class CurriculumPartConfiguration : IEntityTypeConfiguration<CurriculumPart>
    {
        public void Configure(EntityTypeBuilder<CurriculumPart> builder)
        {
            builder.HasKey(x => x.CurriculumPartId);
            builder.HasIndex(x => x.CurriculumPartId).IsUnique();
        }
    }
}
