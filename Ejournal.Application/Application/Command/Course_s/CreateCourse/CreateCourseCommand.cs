using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Course_s.CreateCourse
{
    public class CreateCourseCommand : IRequest<Guid>
    {
        public string Name { get; set; } 
    }
}
