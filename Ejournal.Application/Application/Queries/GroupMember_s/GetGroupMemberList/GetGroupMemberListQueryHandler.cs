using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Common.Helpers.Predicate;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberList
{
    public class GetGroupMemberListQueryHandler 
        : IRequestHandler<GetGroupMemberListQuery, GroupMemberListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGroupMemberListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }
        public async Task<GroupMemberListResponseVm> Handle(GetGroupMemberListQuery request, CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<StudentGroupMember>();
            var entity =
              await _dbContext.StudentGroupMembers
                .Where(predicate 
                    .And(x => x.StudentGroupId == request.GroupId)
                    .And(x => x.Active == request.Parametrs.Active,
                        request.Parametrs.Active))
                .Include(x => x.User)
                .Include(p => p.StudentGroup)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<GroupMemberLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(StudentGroupMember), request.GroupId);

            return new GroupMemberListResponseVm(entity, request.Parametrs);
        }
    }
}
