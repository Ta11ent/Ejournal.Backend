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
            
            //Act
            var result = await handler.Handle(
                    new GetDepartmentMemberDetailsQuery
                    {
                        DepartmentId = ContextFactory.IdParent,
                        MembershipId = ContextFactory.IdForDelete
                    },
                    CancellationToken.None
                );
            result.ShouldBeOfType<DepartmentMemberDetailsResponseVm>();
            result.Data.UserId.ShouldBe(ContextFactory.IdUser);
            result.Data.FirstName.ShouldBe("FirstName " + ContextFactory.IdUser.ToString().Substring(0, 5));
            result.Data.MiddleName.ShouldBe("MiddleName " + ContextFactory.IdUser.ToString().Substring(0, 5));
            result.Data.LastName.ShouldBe("LastName " + ContextFactory.IdUser.ToString().Substring(0, 5));
            result.Data.Gender.ShouldBe(true);
            result.Data.Active.ShouldBe(true);
        }
    }
}
