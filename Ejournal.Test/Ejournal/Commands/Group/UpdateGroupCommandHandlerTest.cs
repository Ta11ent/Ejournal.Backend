using Ejournal.Application.Application.Command.Goup_s.UpdateGroup;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.Group
{
    public class UpdateGroupCommandHandlerTest : CommandTestBase<GroupContextFactory>
    {
        [Fact]
        public async Task UpdateGroupCommandHandler_Succes()
        {
            //Arrange
            var handler = new UpdateGroupCommandHandler(context);
            var updateName = "Test Name Update";
            var active = false;

            //Act
            await handler.Handle(new UpdateGroupCommand
            {
                GroupId = ContextFactory.IdForUpdate,
                Name = updateName,
                Active = active
            },
            CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.StudentGroups.SingleOrDefaultAsync(group =>
                    group.StudentGroupId == ContextFactory.IdForUpdate &&
                    group.Name == updateName &&
                    group.Active == active));
        }

        [Fact]
        public async Task UpdateCourseCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateGroupCommandHandler(context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                       new UpdateGroupCommand
                       {
                           GroupId = Guid.NewGuid()
                       },
                        CancellationToken.None));
        }
    }
}
