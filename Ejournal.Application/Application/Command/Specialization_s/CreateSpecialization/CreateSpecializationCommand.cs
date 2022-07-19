using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.CreateSpecialization
{
    public class CreateSpecializationCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
