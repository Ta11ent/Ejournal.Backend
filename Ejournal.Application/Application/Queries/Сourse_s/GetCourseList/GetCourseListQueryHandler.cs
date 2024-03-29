﻿using AutoMapper;
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

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList
{
    public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, CourseListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCourseListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<CourseListResponseVm> Handle(GetCourseListQuery request,
            CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<Course>();
            var entity =
                await _dbContext.Courses
                .Where(predicate
                    .And(x => x.Active == request.Parametrs.Active,
                        request.Parametrs.Active))
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<CourseLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var count = await _dbContext.Courses.CountAsync();

            return new CourseListResponseVm(entity, request.Parametrs, count);
        }
    }
}
