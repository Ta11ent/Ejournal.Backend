using Ejournal.Application.Application.Command.Goup_s.CreateGroup;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.Group
{
    public class CreateGroupCommandHandlerTest : CommandTestBase<GroupContextFactory>
    {

        [Fact]
        public async Task CreateGroupCommandHandler_Succes()
        {
            //Arrange
            var handler = new CreateGroupCommandHandler(context);
            var groupName = "Test Group Name";
            var specializationId = Guid.NewGuid();
            var startDate = DateTime.Now;//new DateTime().AddYears(-1);
            var endDate = DateTime.Now;

            //Act
            var GroupId = await handler.Handle(
                    new CreateGroupCommand
                    {
                        Name = groupName,
                        SpecializationId = specializationId,
                        StartDate = startDate,
                        EndDate = endDate 
                    },
                    CancellationToken.None
                );

            //Assert
            Assert.NotNull(
                await context.StudentGroups.SingleOrDefaultAsync(group =>
                    group.StudentGroupId == GroupId &&
                    group.Name == groupName &&
                    group.StartDate == startDate &&
                    group.EndDate == endDate &&
                    group.SpecializationId == specializationId));
        }
    }
}
