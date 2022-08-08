using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList
{
    public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, DepartmentListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDepartmentListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<DepartmentListResponseVm> Handle(GetDepartmentListQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Departments
                .Where(dt => dt.Active == request.Parametrs.Active)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<DepartmentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DepartmentListResponseVm(entity, request.Parametrs);
        }
    }
}
