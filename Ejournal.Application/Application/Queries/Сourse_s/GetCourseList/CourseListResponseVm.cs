using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList
{
    public class CourseListResponseVm : PageResponse<List<CourseLookupDto>>
    {
       public CourseListResponseVm(List<CourseLookupDto> data, IPaginationParams parametrs, int count)
            : base(data, parametrs, count) { }
    }
}
