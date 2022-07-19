using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Part_s.CreatePart
{
    public class CreatePartCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
