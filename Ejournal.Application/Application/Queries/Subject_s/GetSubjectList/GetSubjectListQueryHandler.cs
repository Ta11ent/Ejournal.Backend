using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectList
{
    public class GetSubjectListQueryHandler : IRequestHandler<GetSubjectListQuery, SubjectListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetSubjectListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        public async Task<SubjectListResponseVm> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Subjects
                .Where(x => x.Active == request.Parametrs.Active)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<SubjectLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SubjectListResponseVm(entity, request.Parametrs);
        }
    }
}
