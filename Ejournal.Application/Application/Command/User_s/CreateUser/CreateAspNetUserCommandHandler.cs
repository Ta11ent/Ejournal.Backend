using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Ejournal.Application.Application.Command.User_s.CreateUser
{
    public class CreateAspNetUserCommandHandler : IRequestHandler<CreateAspNetUserCommand>
    {
        private readonly IPersonDbContext _dbContext;
        public CreateAspNetUserCommandHandler(IPersonDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Unit> Handle(CreateAspNetUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AspNetUser
            {
                Id = request.Id,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                UserName = request.Email,
                NormalizedUserName = request.Email.ToUpper(),
                AccessFailedCount = 0,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                PasswordHash = new PasswordHasher().HashPassword(request.Password),
                AccountConfirmed = false
            };

            await _dbContext.AspNetUsers.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
