﻿using AutoMapper;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.User_s.GetUserDetails
{
    public class GetUserDetailsQueryHandler 
        //: IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IIdentityDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserDetailsQueryHandler(IIdentityDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }
        //public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        //{
        //    var entity = await
        //       _dbContext.AspNetUsers
        //       .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        //    if (entity == null)
        //        throw new NotFoundException(nameof(AspNetUser), request.Id);

        //    return _mapper.Map<UserDetailsVm>(entity);
        //}
    }
}
