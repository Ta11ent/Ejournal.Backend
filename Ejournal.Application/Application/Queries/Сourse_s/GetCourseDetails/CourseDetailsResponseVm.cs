using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseDetails
{
    public class CourseDetailsResponseVm : Response<CourseDetailsDto>
    {
        public CourseDetailsResponseVm(CourseDetailsDto data)
            : base(data) { }
    }
}
