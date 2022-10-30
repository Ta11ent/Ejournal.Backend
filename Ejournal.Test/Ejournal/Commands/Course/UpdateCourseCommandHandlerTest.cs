using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Ejournal.Command.Course_s.UpdateCourse;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.Course
{
    public class UpdateCourseCommandHandlerTest : CommandTestBase<CourseContextFactory>
    {
        [Fact]
        public async Task UpdateCourseCommandHandler_Succes()
        {
            //Arrange
            var handler = new UpdateCourseCommandHandler(context);
            var updateName = "Test Name Update";
            var active = false;

            //Act
            await handler.Handle(new UpdateCourseCommand
            {
                CourseId = ContextFactory.IdForUpdate,
                Name = updateName,
                Active = active
            },
            CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Courses.SingleOrDefaultAsync(course =>
                    course.CourseId == ContextFactory.IdForUpdate &&
                    course.Name == updateName &&
                    course.Active == active));
        }

        [Fact]
        public async Task UpdateCourseCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateCourseCommandHandler(context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                       new UpdateCourseCommand{
                           CourseId = Guid.NewGuid()
                       },
                        CancellationToken.None));
        }
    }
}
