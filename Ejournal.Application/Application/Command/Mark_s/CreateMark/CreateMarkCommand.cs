using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Mark_s.CreateMark
{
    public class CreateMarkCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
