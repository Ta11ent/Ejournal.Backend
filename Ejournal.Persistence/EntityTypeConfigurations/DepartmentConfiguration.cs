using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DepartmentId);
            builder.HasIndex(x => x.DepartmentId).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Description).HasMaxLength(100);
        }
    }
}
