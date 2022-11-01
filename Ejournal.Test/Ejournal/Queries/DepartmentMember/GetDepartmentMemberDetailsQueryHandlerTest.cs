using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails;
using Ejournal.Test.Common;
using Ejournal.Test.Common.DataDomains;
using Ejournal.Test.Common.Factories;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Queries.DepartmentMember
{
    public class GetDepartmentMemberDetailsQueryHandlerTest : QueryTestFixture<DepartmentMemberContextFactory>
    {
        [Fact]
        public async Task GetDepartmentDetailsQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetDepartmentMemberDetailsQueryHandler(mapper, context);

            var department = new DataDepartment(ContextFactory.IdParent);
            department.Create();

            var user = new DataUser(ContextFactory.IdParent);
            user.Create();

            var dptMember = new DataDepartmentMember(ContextFactory.IdParent, ContextFactory.IdForDelete);
            dptMember.UserId = user.Data.UserId;
            dptMember.Create();
            
            //Act
            var result = await handler.Handle(
                    new GetDepartmentMemberDetailsQuery
                    {
                        DepartmentId = department.Data.DepartmentId,
                        MembershipId = dptMember.Data.DepartmentMemberId
                    },
                    CancellationToken.None
                );
            result.ShouldBeOfType<DepartmentMemberDetailsResponseVm>();
            result.Data.UserId.ShouldBe(dptMember.Data.UserId);
            result.Data.FirstName.ShouldBe(user.Data.FirstName);
            result.Data.MiddleName.ShouldBe(user.Data.MiddleName);
            result.Data.LastName.ShouldBe(user.Data.LastName);
            result.Data.Gender.ShouldBe(user.Data.Gender);
            result.Data.Active.ShouldBe(user.Data.Active);
        }
    }
}
