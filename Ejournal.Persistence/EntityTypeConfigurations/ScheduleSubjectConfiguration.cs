using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class ScheduleSubjectConfiguration : IEntityTypeConfiguration<ScheduleSubject>
    {
        public void Configure(EntityTypeBuilder<ScheduleSubject> builder)
        {
            builder.HasKey(x => x.ScheduleSubjectId);
            builder.HasIndex(x => x.ScheduleSubjectId).IsUnique();
        }
    }
}
