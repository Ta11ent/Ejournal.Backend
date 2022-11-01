using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Queries.DepartmentMember
{
    public class GetDepartmentMemberListHandlerTest : QueryTestFixture<DepartmentMemberContextFactory>
    {
        [Fact]
        public async Task GetDepartmentMemberListQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetDepartmentMemberListQueryHandler(mapper, context);

            //Act
            var result = await handler.Handle(
                new GetDepartmentMemberListQuery()
                {
                    DepartmentId = ContextFactory.IdParent,
                    Parametrs = new FilterParams()
                },
                    CancellationToken.None);

            //Assert
            result.ShouldBeOfType<DepartmentMemberListResponseVm>();
            result.Records.ShouldBe(3);
        }

        [Fact]
        public async Task GetDepartmentMemberFilteredListQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetDepartmentMemberListQueryHandler(mapper, context);

            //Act
            var result = await handler.Handle(
                new GetDepartmentMemberListQuery()
                {
                    DepartmentId = ContextFactory.IdParent,
                    Parametrs = new FilterParams()
                    {
                        Page = 1,
                        PageSize = 2,
                        Active = false
                    }
                },
                    CancellationToken.None);

            //Assert
            result.ShouldBeOfType<DepartmentMemberListResponseVm>();
            result.Records.ShouldBe(1);
        }
    }
}
