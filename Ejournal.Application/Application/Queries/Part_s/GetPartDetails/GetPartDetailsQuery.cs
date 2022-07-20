using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartDetails
{
    public class GetPartDetailsQuery : IRequest<PartDetailsResponseVm>
    {
        public Guid PartId { get; set; }
    }
}
