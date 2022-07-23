using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupDetails
{
    public class GetGroupDetailsQuery : IRequest<GroupDetailsResponseVm>
    {
        public Guid GroupId { get; set; }
    }
}
