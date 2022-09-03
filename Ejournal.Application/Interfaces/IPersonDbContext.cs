using Ejournal.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Interfaces
{
    public interface IPersonDbContext
    {
        DbSet<AspNetUser> AspNetUsers { get; set; }
        DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
