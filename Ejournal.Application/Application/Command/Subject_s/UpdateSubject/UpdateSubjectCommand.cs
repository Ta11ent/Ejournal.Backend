using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Subject_s.UpdateSubject
{
    public class UpdateSubjectCommand : IRequest
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
