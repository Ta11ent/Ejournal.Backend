using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ejournal.Application.Interfaces
{
    public interface IIdentityDbContext
    {
        DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}
