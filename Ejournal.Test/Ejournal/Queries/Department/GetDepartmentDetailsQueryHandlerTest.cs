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

            //Act
            var result = await handler.Handle(
                    new GetDepartmentDetailsQuery
                    {
                        DepartmentId = ContextFactory.IdForDelete
                    },
                    CancellationToken.None
                );
            result.ShouldBeOfType<DepartmentDetailsResponseVm>();
            result.Data.Name.ShouldBe("Test Name " + ContextFactory.IdForDelete.ToString().Substring(0, 5));
            result.Data.Description.ShouldBe("Test Description " + ContextFactory.IdForDelete.ToString().Substring(0, 5));
            result.Data.Active.ShouldBe(true);
        }
    }
}
