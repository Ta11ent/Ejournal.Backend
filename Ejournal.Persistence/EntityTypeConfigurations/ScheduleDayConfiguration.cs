using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class ScheduleDayConfiguration : IEntityTypeConfiguration<ScheduleDay>
    {
        public void Configure(EntityTypeBuilder<ScheduleDay> builder)
        {
            builder.HasKey(x => new { x.ScheduleId, x.Day }).IsClustered();
            builder.HasIndex(x => x.ScheduleDayId).IsUnique();
            builder.Property(x => x.ScheduleDayId).HasMaxLength(38);
        }
    }
}
