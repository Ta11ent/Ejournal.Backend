using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Queries.Curriculum_s.GetCurriculumList
{
    public class GetCurriculumsListQueryHandler : IRequestHandler<GetCurriculumsListQuery, CurriculumListVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCurriculumsListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        public async Task<CurriculumListVm> Handle(GetCurriculumsListQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Curriculums
                .Where(dt => dt.Active == request.Active)
                .ProjectTo<CurriculumLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CurriculumListVm { Curriculums = entity };
        }
    }
}
