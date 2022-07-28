using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ejournal.Persistence.EntityTypeConfigurations
{
    public class UserConfigaration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasIndex(x => x.UserId).IsUnique();
            builder.Property(x => x.FirstName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.MiddleName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(20).IsRequired();
        }
    }
}
