using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Queries.Curriculum_s.GetCurriculumDetails
{
    public class GetCurriculumDetailsQuery : IRequest<CurriculumDetailsVm>
    {
        public Guid CurriculumId { get; set; }
    }
}
