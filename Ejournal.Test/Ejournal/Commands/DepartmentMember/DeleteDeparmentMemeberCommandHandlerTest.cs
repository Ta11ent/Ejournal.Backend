using Ejournal.Application.Application.Command.DepartmentMember_s.DeleteDepartmentMember;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.DepartmentMember
{
    public class DeleteDeparmentMemeberCommandHandlerTest : CommandTestBase<DepartmentMemberContextFactory>
    {
        [Fact]
        public async Task DeleteDepartmenrMemberCommandHandler_Succes()
        {
            //Arrange
            var handler = new DeleteDepartmentMemberCommandHandler(context);

            //Act
            await handler.Handle(
                    new DeleteDepartmentMemberCommand
                    {
                        DepartmentId = ContextFactory.IdParent,
                        MembershipId = ContextFactory.IdForDelete
                    },
                    CancellationToken.None
                );

            //Assert
            Assert.Null(context.DepartmentMembers.SingleOrDefault(dptMember =>
                dptMember.DepartmentId == ContextFactory.IdParent &&
                dptMember.DepartmentMemberId == ContextFactory.IdForDelete));
        }

        [Fact]
        public async Task DeleteDepartmentMemberCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteDepartmentMemberCommandHandler(context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteDepartmentMemberCommand
                    {
                        DepartmentId = Guid.NewGuid(),
                        MembershipId = Guid.NewGuid()
                    },
                    CancellationToken.None)
            );
        }
    }
}
