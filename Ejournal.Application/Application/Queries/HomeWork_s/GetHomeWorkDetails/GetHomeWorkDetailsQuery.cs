using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkDetails
{
    public class GetHomeWorkDetailsQuery : IRequest<HomeWorkDetailsResponseVm>
    {
        public Guid HomeWorkId { get; set; }
    }
}
