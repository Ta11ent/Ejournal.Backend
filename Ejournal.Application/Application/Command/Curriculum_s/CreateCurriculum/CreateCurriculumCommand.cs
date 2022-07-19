using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Curriculum_s.CreateCurriculum
{
    public class CreateCurriculumCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid CourseId { get; set; }
    }
}
