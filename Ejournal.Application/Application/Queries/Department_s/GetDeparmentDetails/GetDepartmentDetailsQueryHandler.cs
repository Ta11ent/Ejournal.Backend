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

namespace Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails
{
    public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentDetailsQuery, DepartmentDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public GetDepartmentDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<DepartmentDetailsResponseVm> Handle(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Departments
                .Where(sp => sp.DepartmentId == request.DepartmentId)
                .ProjectTo<DepartmentDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Department), request.DepartmentId);

            return new DepartmentDetailsResponseVm(entity);
        }
    }
}
