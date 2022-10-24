using Ejournal.Test.Common;
using Ejournal.Application.Ejournal.Command.Course_s.DeleteCourse;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Ejournal.Application.Common.Exceptions;
using System;

namespace Ejournal.Test.Ejournal.Command
{
    public class DeleteCourseCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task DeleteCourseCommandHandler_Succees()
        {
            //Arrange
            var handler = new DeleteCourseCommandHandler(Context);

            //Act
            await handler.Handle(
                new DeleteCourseCommand
                {
                    CourseId = ContextFactory.IdForDelete
                },
                CancellationToken.None
            );

            //Assert
            Assert.Null(Context.Courses.SingleOrDefault(course =>
                course.CourseId == ContextFactory.IdForDelete));
        }

        [Fact]
        public async Task DeleteCourseCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteCourseCommandHandler(Context);

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
