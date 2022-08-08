using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Behaviors;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationDetails
{
    public class GetSpecializationDetailsQueryHandler : 
        IRequestHandler<GetSpecializationDetailsQuery, SpecializationDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSpecializationDetailsQueryHandler(IEjournalDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<SpecializationDetailsResponseVm> Handle(GetSpecializationDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Specializations
                .Where(sp => sp.SpecializationId == request.SpecializationId)
                .ProjectTo<SpecializationDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Specialization), request.SpecializationId);

            return new SpecializationDetailsResponseVm(entity);  

        }
    }
}