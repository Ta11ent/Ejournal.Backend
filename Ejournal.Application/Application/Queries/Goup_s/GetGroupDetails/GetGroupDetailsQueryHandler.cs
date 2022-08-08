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

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupDetails
{
    public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, GroupDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGroupDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<GroupDetailsResponseVm> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.StudentGroups
                .Where(sp => sp.StudentGroupId == request.GroupId)
                .Include(s => s.Specialization)
                .ProjectTo<GroupDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(StudentGroup), request.GroupId);

            return new GroupDetailsResponseVm(entity);
        }
    }
}
