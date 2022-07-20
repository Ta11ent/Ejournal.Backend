using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartDetails
{
    public class GetPartDetailsQueryHandler : IRequestHandler<GetPartDetailsQuery, PartDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly Mapper _mapper;
        public GetPartDetailsQueryHandler(IEjournalDbContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        public async Task<PartDetailsResponseVm> Handle(GetPartDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Parts
                .Where(p => p.PartId == request.PartId)
                .ProjectTo<PartDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if(entity == null)
                throw new NotFoundException(nameof(Part), request.PartId);

            return new PartDetailsResponseVm(entity);
        }
    }
}
