using AutoMapper;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Queries.Curriculum_s.GetCurriculumDetails
{
    public class GetCurriculumDetailsQueryHandler : IRequestHandler<GetCurriculumDetailsQuery, CurriculumDetailsVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCurriculumDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }
        public async Task<CurriculumDetailsVm> Handle(GetCurriculumDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext.Curriculums
                .FirstOrDefaultAsync(c => c.CurriculumId == request.CurriculumId, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Curriculum), request.CurriculumId);

            return _mapper.Map<CurriculumDetailsVm>(entity);
        }
    }
}
