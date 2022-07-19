using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class RaitingLogConfiguration : IEntityTypeConfiguration<RatingLog>
    {
        public void Configure(EntityTypeBuilder<RatingLog> builder)
        {
            builder.HasKey(x => x.RaitingLogId);
            builder.HasIndex(x => x.RaitingLogId).IsUnique();
            builder.Property(x => x.Description).HasMaxLength(300);
        }
    }
}
