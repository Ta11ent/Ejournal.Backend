using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectDetails
{
    public class GetSubjectDetailsQuery : IRequest<SubjectDetailsResponseVm>
    {
        public Guid SubjectId { get; set; }
    }
}
