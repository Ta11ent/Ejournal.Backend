using Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.DepartmentMember
{
    public class CreateDepartmentMemberCommandHandlerTest : CommandTestBase<DepartmentMemberContextFactory>
    {
        [Fact]
        public async Task CreateDepartmentMemberCommandHandler_Succes()
        {
            //Arrange
            var handler = new CreateDepartmentMemberCommandHandler(context);
            var departmentId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            //Act
            var dptMemberId = await handler.Handle(
                    new CreateDepartmentMemberCommand
                    {
                        DepartmentId = departmentId,
                        UserId = userId
                    },
                    CancellationToken.None
                );

            //Assert
            Assert.NotNull(
                await context.DepartmentMembers.SingleOrDefaultAsync(dptMember =>
                    dptMember.DepartmentMemberId == dptMemberId &&
                    dptMember.DepartmentId == departmentId &&
                    dptMember.UserId == userId &&
                    dptMember.Active == true));

        }
    }
}
