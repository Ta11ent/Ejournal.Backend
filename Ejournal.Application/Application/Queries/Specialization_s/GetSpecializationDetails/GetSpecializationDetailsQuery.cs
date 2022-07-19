using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationDetails
{
 public class GetSpecializationDetailsQuery : IRequest<SpecializationDetailsResponseVm>
    {
        public Guid SpecializationId { get; set; }
    }
}