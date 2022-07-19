using MediatR;

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList
{
    public class GetCourseListQuery : IRequest<CourseListVm>
    {
        public bool Active { get; set; }
    }
}
