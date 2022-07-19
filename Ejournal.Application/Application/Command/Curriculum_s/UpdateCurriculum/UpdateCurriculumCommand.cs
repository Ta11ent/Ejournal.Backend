using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Curriculum_s.UpdateCurriculum
{
    public class UpdateCurriculumCommand : IRequest
    {
        public Guid CurriculumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid CourseId { get; set; }
    }
}
