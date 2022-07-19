using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class StudentGroupMemberConfiguration : IEntityTypeConfiguration<StudentGroupMember>
    {
        public void Configure(EntityTypeBuilder<StudentGroupMember> builder)
        {
            builder.HasKey(x => x.StudentGroupMemberId);
            builder.HasIndex(x => x.StudentGroupMemberId).IsUnique();
            //builder.Property(x => x.bActive).HasDefaultValue(true);
        }
    }
}
