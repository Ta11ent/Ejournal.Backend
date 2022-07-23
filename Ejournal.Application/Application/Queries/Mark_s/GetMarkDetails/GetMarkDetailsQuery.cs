using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkDetails
{
    public class GetMarkDetailsQuery : IRequest<MarkDetailsResponseVm>
    {
        public Guid MarkId { get; set; }
    }
}
