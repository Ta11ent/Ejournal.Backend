using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class CurriculumPartSubjectConfiguration : IEntityTypeConfiguration<CurriculumPartSubject>
    {
        public void Configure(EntityTypeBuilder<CurriculumPartSubject> builder)
        {
            builder.HasKey(X => X.CurriculumPartSubjectId);
            builder.HasIndex(x => x.CurriculumPartSubjectId).IsUnique();
        }
    }
}
