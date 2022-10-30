using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Queries.Department
{
    public class GetDepartmentListHandlerTest : QueryTestFixture<DepartmentContextFactory>
    {
        [Fact]
        public async Task GetDepartmentListQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetDepartmentListQueryHandler(context, mapper);

            //Act
            var result = await handler.Handle(
                new GetDepartmentListQuery()
                {
                    Parametrs = new FilterParams()
                },
                    CancellationToken.None);

            //Assert
            result.ShouldBeOfType<DepartmentListResponseVm>();
            result.Records.ShouldBe(3);
        }

        [Fact]
        public async Task GetDepartmentFilteredListQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetDepartmentListQueryHandler(context, mapper);

            //Act
            var result = await handler.Handle(
                new GetDepartmentListQuery()
                {
                    Parametrs = new FilterParams()
                    {
                        Page = 1,
                        PageSize = 2,
                        Active = false
                    }
                },
                    CancellationToken.None);

            //Assert
            result.ShouldBeOfType<DepartmentListResponseVm>();
            result.Records.ShouldBe(1);
        }
    }
}
