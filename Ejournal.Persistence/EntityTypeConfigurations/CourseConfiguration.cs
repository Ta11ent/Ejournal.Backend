using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.CourseId);
            builder.HasIndex(x => x.CourseId).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
        }
    }
}
