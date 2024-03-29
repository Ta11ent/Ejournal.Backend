﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ejournal.Domain;

using Ejournal.Application.Common.Helpers.Predicate;

namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogList
{
    public class GetRatingLogListQueryHandler 
        : IRequestHandler<GetRatingLogListQuery, RatingLogListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRatingLogListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<RatingLogListResponseVm> Handle(GetRatingLogListQuery request,
            CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<RatingLog>();
            var entity =
                await _dbContext.RaitingLogs
                    .Where(predicate
                        .And(x => x.DepartmentMemberId == request.Parametrs.Membership, 
                            request.Parametrs.Membership)
                        .And(x => x.StudentGroupMemberId == request.Parametrs.ClassMember, 
                            request.Parametrs.ClassMember)
                        .And(x => x.SubjectId == request.Parametrs.Subject, 
                            request.Parametrs.Subject)
                        .And(x => x.StudentGroupMember.StudentGroupId == request.Parametrs.Group, 
                            request.Parametrs.Group)
                        .And(x => x.Date >= request.Parametrs.DateFrom,
                            request.Parametrs.DateFrom)
                        .And(x => x.Date <= request.Parametrs.DateTo,
                            request.Parametrs.DateTo))
                    .Include(s => s.StudentGroupMember)
                        .ThenInclude(u => u.User)
                    .Include(d => d.DepartmentMember)
                        .ThenInclude(p => p.User)
                    .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                    .Take(request.Parametrs.PageSize)
                    .ProjectTo<RatingLogLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            var count = await _dbContext.RaitingLogs.CountAsync();

            return new RatingLogListResponseVm(entity, request.Parametrs, count);
        }
    }
}
