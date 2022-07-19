using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Part_s.UpdatePart
{
    public class UpdatePartCommand : IRequest
    {
        public Guid PartId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
