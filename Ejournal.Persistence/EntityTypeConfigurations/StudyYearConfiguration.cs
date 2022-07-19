using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class StudyYearConfiguration : IEntityTypeConfiguration<StudyYear>
{
    public void Configure(EntityTypeBuilder<StudyYear> builder)
    {
        builder.HasKey(x => x.StudyYearId);
        builder.HasIndex(x => x.StudyYearId).IsUnique();
    }
}