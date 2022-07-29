using Ejournal.Application.Common.Helpers.Filters;
using MediatR;

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList
{
    public class GetCourseListQuery : IRequest<CourseListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
