using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Curriculum_s.DeleteCurriculum
{
    public class DeleteCurriculumCommand : IRequest
    {
        public Guid CurriculumId { get; set; }
    }
}
