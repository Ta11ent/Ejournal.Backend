using System;
using MediatR;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.UpdateSpecialization
{
    public class UpdateSpecializationCommand : IRequest
    {
        public Guid SpecializationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public bool bActive { get; set; }
    }
}
