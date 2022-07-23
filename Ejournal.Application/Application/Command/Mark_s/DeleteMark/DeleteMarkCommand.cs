using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Mark_s.DeleteMark
{
    public class DeleteMarkCommand : IRequest
    {
        public Guid MarkId { get; set; }
    }
}
