using Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails;
using Ejournal.Test.Common;
using Ejournal.Test.Common.DataDomains;
using Ejournal.Test.Common.Factories;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Queries.Department
{
    public class GetDepartmentDetailsQueryHandlerTest : QueryTestFixture<DepartmentContextFactory>
    {
        [Fact]
        public async Task GetDepartmentDetailsQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetDepartmentDetailsQueryHandler(context, mapper);

            var department = new DataDepartment(ContextFactory.IdForDelete);
            department.Create();

            //Act
            var result = await handler.Handle(
                    new GetDepartmentDetailsQuery
                    {
                        DepartmentId = department.Data.DepartmentId
                    },
                    CancellationToken.None
                );
            result.ShouldBeOfType<DepartmentDetailsResponseVm>();
            result.Data.Name.ShouldBe(department.Data.Name);
            result.Data.Active.ShouldBe(department.Data.Active);
        }
    }
}
