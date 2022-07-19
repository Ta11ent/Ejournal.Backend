using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.DeleteSpecialization
{
    public class DeleteSpecializationCommand : IRequest
    {
        public Guid SpecialiationId { get; set; }
    }
}