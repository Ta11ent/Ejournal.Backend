using Ejournal.Test.Common;
using Ejournal.Application.Ejournal.Command.Course_s.CreateCourse;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Ejournal.Test.Common.Factories;

namespace Ejournal.Test.Ejournal.Commands.Course
{
    public class CreateCourseCommandHandlerTest : CommandTestBase<CourseContextFactory>
    {
        [Fact]
        public async Task CreateCourseCommandHandler_Succes()
        {
            //Arrange
            var handler = new CreateCourseCommandHandler(context);
            var courseName = "Test Course Name";

            //Act
            var courseId = await handler.Handle(
                    new CreateCourseCommand
                    {
                        Name = courseName
                    },
                    CancellationToken.None
                );

            //Assert
            Assert.NotNull(
                await context.Courses.SingleOrDefaultAsync(course =>
                    course.CourseId == courseId &&
                    course.Name == courseName &&
                    course.Active == true));

        }
    }
}
