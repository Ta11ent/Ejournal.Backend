using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Goup_s.UpdateGroup
{
    public class UpdateGroupCommand : IRequest
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
