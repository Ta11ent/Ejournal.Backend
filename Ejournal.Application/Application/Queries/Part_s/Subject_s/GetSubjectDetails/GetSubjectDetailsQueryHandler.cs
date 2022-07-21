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

namespace Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectDetails
{
    public class GetSubjectDetailsQueryHandler : IRequestHandler<GetSubjectDetailsQuery, SubjectDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetSubjectDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        public async Task<SubjectDetailsResponseVm> Handle(GetSubjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Subjects
                .Where(p => p.SubjectId == request.SubjectId)
                .Include(d => d.Department)
                .ProjectTo<SubjectDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Subject), request.SubjectId);

            return new SubjectDetailsResponseVm(entity);
        }
    }
}
