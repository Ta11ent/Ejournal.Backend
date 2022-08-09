using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.User_s.CreateUser
{
    public class CreateAspNetUserCommandHandler : IRequestHandler<CreateAspNetUserCommand, string>
    {
        private readonly IPersonDbContext _dbContext;
        public CreateAspNetUserCommandHandler(IPersonDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<string> Handle(CreateAspNetUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AspNetUser
            {
                Id = request.Id,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            await _dbContext.AspNetUsers.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return "Test";
        }
    }
}
