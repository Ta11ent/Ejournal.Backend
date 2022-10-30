using Ejournal.Test.Common;
using Ejournal.Application.Ejournal.Command.Course_s.DeleteCourse;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Ejournal.Application.Common.Exceptions;
using System;
using Ejournal.Test.Common.Factories;

namespace Ejournal.Test.Ejournal.Commands.Course
{
    public class DeleteCourseCommandHandlerTest : CommandTestBase<CourseContextFactory>
    {
        [Fact]
        public async Task DeleteCourseCommandHandler_Succees()
        {
            //Arrange
            var handler = new DeleteCourseCommandHandler(context);

            //Act
            await handler.Handle(
                new DeleteCourseCommand
                {
                    CourseId = ContextFactory.IdForDelete
                },
                CancellationToken.None
            );

            //Assert
            Assert.Null(context.Courses.SingleOrDefault(course =>
                course.CourseId == ContextFactory.IdForDelete));
        }

        [Fact]
        public async Task DeleteCourseCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteCourseCommandHandler(context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteCourseCommand {
                        CourseId = Guid.NewGuid()
                    },
                    CancellationToken.None)
            );
        }
    }
}
