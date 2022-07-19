using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails
{
    public class GetDepartmentDetailsQuery : IRequest<DepartmentDetailsResponseVm>
    {
        public Guid DepartmentId { get; set; }
    }
}
