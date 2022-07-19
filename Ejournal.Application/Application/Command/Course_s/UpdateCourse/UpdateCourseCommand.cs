using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Course_s.UpdateCourse
{
    public class UpdateCourseCommand : IRequest
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
    }
}
