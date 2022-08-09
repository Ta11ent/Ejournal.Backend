using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            _dbContextI = dbContextI ?? throw new ArgumentNullException(nameof(dbContextI));
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = CreateUser(request);
        
            await _dbContextJ.Users.AddAsync(user, cancellationToken);
            await _dbContextJ.SaveChangesAsync(cancellationToken);

            if (request.CreateIdentity)
            {
                var result = await _userManager.CreateAsync(CreateAspNetUser(user.UserId, request), request.Password);

            }
        }
        private User CreateUser(CreateUserCommand request)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Gender = request.Gender,
                Active = request.Active
            };
        }
        private AspNetUser CreateAspNetUser(Guid id, CreateUserCommand request)
        {
            return new AspNetUser
            {
                Id = id,
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };
        }
    }
}
