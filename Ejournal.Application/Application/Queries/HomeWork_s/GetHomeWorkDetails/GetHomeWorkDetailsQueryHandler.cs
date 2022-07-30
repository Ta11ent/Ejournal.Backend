using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkDetails
{
    public class GetHomeWorkDetailsQueryHandler 
        : IRequestHandler<GetHomeWorkDetailsQuery, HomeWorkDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetHomeWorkDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }
        public async Task<HomeWorkDetailsResponseVm> Handle(GetHomeWorkDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.HomeWorks
                .Where(x => x.HomeWorkId == request.HomeWorkId)
                .Include(s => s.Subject)
                .Include(g => g.StudentGroup)
                .ProjectTo<HomeWorkDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(HomeWorkDetailsDto), request.HomeWorkId);

            return new HomeWorkDetailsResponseVm(entity);
        }
    }
}
