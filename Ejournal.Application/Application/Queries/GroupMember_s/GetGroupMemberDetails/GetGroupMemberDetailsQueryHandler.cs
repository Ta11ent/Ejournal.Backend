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

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberDetails
{
    public class GetGroupMemberDetailsQueryHandler
        : IRequestHandler<GetGroupMemberDetailsQuery, GroupMemberDetailsResponseVm>
    {
        private readonly IMapper _mapper;
        private readonly IEjournalDbContext _dbContext;

        public GetGroupMemberDetailsQueryHandler(IMapper mapper, IEjournalDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task<GroupMemberDetailsResponseVm> Handle(GetGroupMemberDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.StudentGroupMembers
                .Include(gm => gm.StudentGroup)
                .Include(s => s.Student)
                .Where(e =>
                  e.StudentGroupId == request.GroupId &&
                  e.StudentGroupMemberId == request.MemberId)
                .ProjectTo<GroupMemberDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(StudentGroupMember), request.MemberId);

            return new GroupMemberDetailsResponseVm(entity);
        }
    }
}
