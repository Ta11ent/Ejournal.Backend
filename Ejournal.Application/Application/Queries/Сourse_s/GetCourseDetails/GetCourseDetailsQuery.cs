using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseDetails
{
    public class GetCourseDetailsQuery : IRequest<CourseDetailsResponseVm>
    {
        public Guid CourseId { get; set; }
    }
}
