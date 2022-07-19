using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class DepartmentMemberConfiguration : IEntityTypeConfiguration<DepartmentMember>
    {
        public void Configure(EntityTypeBuilder<DepartmentMember> builder)
        {
            builder.HasKey(x => x.DepartmentMemberId);
            builder.HasIndex(x => x.DepartmentMemberId).IsUnique();
        }
    }
}
