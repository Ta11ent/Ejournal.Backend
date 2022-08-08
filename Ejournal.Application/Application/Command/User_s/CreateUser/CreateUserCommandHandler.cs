using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.User_s.CreateUser
{
    public class CreateUserCommandHandler : RequestHandler<CreateUserCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContextJ;
        private readonly IIdentityDbContext _dbContextI;
        public CreateUserCommandHandler(IEjournalDbContext dbContextJ, IIdentityDbContext dbContextI)
        {
            _dbContextJ = dbContextJ ?? throw new ArgumentNullException(nameof(dbContextJ));
        }
    }
}
