using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ejournal.Person
{
    public class PersonDbContext : DbContext, IPersonDbContext
    {
      //  public DbSet<AspNetUser> AspNetUsers { get; set; }
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
