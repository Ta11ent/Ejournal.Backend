using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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
                AccessFailedCount = 0,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true
            };

            await _dbContext.AspNetUsers.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
