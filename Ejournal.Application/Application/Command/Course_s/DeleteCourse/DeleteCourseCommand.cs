using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Course_s.DeleteCourse
{
    public class DeleteCourseCommand : IRequest
    {
        public Guid CourseId { get; set; }
    }
}
