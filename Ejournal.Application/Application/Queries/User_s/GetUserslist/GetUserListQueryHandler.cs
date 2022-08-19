using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Helpers.Predicate;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.User_s.GetUserslist
{
    public class GetUserListQueryHandler 
        : IRequestHandler<GetUserListQuery, UserListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<UserListResponseVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<User>();
            var data = 
                await _dbContext.Users
                .Where(predicate
                    .And(x => x.Active == request.Parametrs.Active)
                    .And(x => x.Birthday >= request.Parametrs.DateFrom,
                        request.Parametrs.DateFrom)
                    .And(x => x.Birthday <= request.Parametrs.DateTo,
                        request.Parametrs.DateTo))
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListResponseVm(data, request.Parametrs);    
        }
    }
}