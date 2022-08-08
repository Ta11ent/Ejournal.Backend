using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkDetails
{
    public class GetMarkDetailsQueryHandller : IRequestHandler<GetMarkDetailsQuery, MarkDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMarkDetailsQueryHandller(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }
        public async Task<MarkDetailsResponseVm> Handle(GetMarkDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Marks
                .Where(m => m.MarkId == request.MarkId)
                .ProjectTo<MarkDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Mark), request.MarkId);

            return new MarkDetailsResponseVm(entity);
        }
    }
}
