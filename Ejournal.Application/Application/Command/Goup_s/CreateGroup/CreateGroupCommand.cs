using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Goup_s.CreateGroup
{
    public class CreateGroupCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
