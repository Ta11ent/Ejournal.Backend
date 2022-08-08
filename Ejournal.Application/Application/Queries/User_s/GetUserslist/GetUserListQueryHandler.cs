using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.User_s.GetUserslist
{
    public class GetUserListQueryHandler 
        //: IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IIdentityDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IIdentityDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        //public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        //{
        //    var entity =
        //        await _dbContext.AspNetUsers
        //        .Where(b => b.Active == request.Active)
        //        .ProjectTo<UserLookupDto>(_mapper.ConfigurationProvider)
        //        .ToListAsync(cancellationToken);

        //    return new UserListVm { Users = entity };
        //}

    }
}
