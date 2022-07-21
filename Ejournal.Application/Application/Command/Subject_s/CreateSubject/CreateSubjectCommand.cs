using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Subject_s.CreateSubject
{
    public class CreateSubjectCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
