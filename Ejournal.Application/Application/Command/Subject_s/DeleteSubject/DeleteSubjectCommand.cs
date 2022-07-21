using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Subject_s.DeleteSubject
{
    public class DeleteSubjectCommand : IRequest
    {
        public Guid SubjectId { get; set; }
    }
}
