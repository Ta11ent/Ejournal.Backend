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
        private readonly IPersonDbContext _identityDbContext;

        public GetGroupMemberDetailsQueryHandler(IMapper mapper,
            IEjournalDbContext dbContext, IPersonDbContext identityDbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _identityDbContext = identityDbContext ?? throw new ArgumentNullException(nameof(_identityDbContext));

        }

        public async Task<GroupMemberDetailsResponseVm> Handle(GetGroupMemberDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.StudentGroupMembers
                .Include(gm => gm.StudentGroup)
                .FirstOrDefaultAsync(e =>
                  e.StudentGroupId == request.GroupId &&
                  e.StudentGroupMemberId == request.GroupMemberId,
                  cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(StudentGroupMember), request.GroupMemberId);
            var model = _mapper.Map<GroupMemberDetailsDto>(entity);

            var dependentEntity =
                await _identityDbContext.AspNetUsers
                .Where(e => e.Id == entity.StudentId)
                .ProjectTo<GroupMember>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (dependentEntity == null)
                throw new NotFoundException(nameof(DepartmentMember), nameof(AspNetUser), entity.StudentId);

            model.Student = dependentEntity;

            return new GroupMemberDetailsResponseVm(model);
        }
    }
}
