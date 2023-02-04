using Ejournal.Application.Application.Command.Goup_s.DeleteGroup;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.Group
{
    public class DeleteGroupCommandHandlerTest : CommandTestBase<GroupContextFactory>
    {
        [Fact]
        public async Task DeleteGroupCommandHandler_Succees()
        {
            //Arrange
            var handler = new DeleteGroupCommandHandler(context);

            //Act
            await handler.Handle(
                new DeleteGroupCommand
                {
                    GroupId = ContextFactory.IdForDelete
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
            var handler = new DeleteGroupCommandHandler(context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteGroupCommand
                    {
                        GroupId = Guid.NewGuid()
                    },
                    CancellationToken.None)
            );
        }
    }
}
