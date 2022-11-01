using Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember;
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

namespace Ejournal.Test.Ejournal.Commands.DepartmentMember
{
    public class UpdateDepartmentMemberCommandHandlerTest : CommandTestBase<DepartmentMemberContextFactory>
    {
        [Fact]
        public async Task DeleteDepartmentMemberCommandHandler_Succes()
        {
            //Arrange
            var handler = new UpdateDepartmentMemberCommandHandler(context);
            var userId = Guid.NewGuid();
            var active = false;

            //Act
            await handler.Handle(new UpdateDepartmentMemberCommand
            {
                DepartmentId = ContextFactory.IdParent,
                MembershipId = ContextFactory.IdForUpdate,
                UserId = userId,
                Active = active
            },
            CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.DepartmentMembers.SingleOrDefaultAsync(dptMember =>
                    dptMember.DepartmentId == ContextFactory.IdParent &&
                    dptMember.DepartmentMemberId == ContextFactory.IdForUpdate &&
                    dptMember.UserId == userId &&
                    dptMember.Active == active));
        }

        [Fact]
        public async Task UpdateDepartmentMemberCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateDepartmentMemberCommandHandler(context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                       new UpdateDepartmentMemberCommand
                       {
                           DepartmentId = Guid.NewGuid(),
                           MembershipId = Guid.NewGuid()
                       },
                        CancellationToken.None));
        }
    }
}
