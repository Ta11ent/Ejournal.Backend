using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Queries.Curriculum_s.GetCurriculumList
{
    public class GetCurriculumsListQuery : IRequest<CurriculumListVm>
    {
        public bool Active { get; set; }
    }
}