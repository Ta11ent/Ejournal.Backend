using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Mark_s.UpdateMark
{
    public class UpdateMarkCommand : IRequest
    {
        public Guid MarkId { get; set; }
        public string Name { get; set; }
    }
}
