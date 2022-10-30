using Ejournal.Application.Ejournal.Command.Department_s.CreateDepartment;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.Department
{
    public class CreateDepartmentCommandHandlerTest : CommandTestBase<DepartmentContextFactory>
    {
        [Fact]
        public async Task CreateDepartmentCommandHandler_Succes()
        {
            //Arrange
            var handler = new CreateDepartmentCommandHandler(context);
            var dptName = "Test Department Name";
            var dptDescrription = "Test Department Description";

            //Act
            var departmentId = await handler.Handle(
                    new CreateDepartmentCommand
                    {
                        Name = dptName,
                        Description = dptDescrription
                    }, 
                    CancellationToken.None
                );
            //Assert
            Assert.NotNull(
                await context.Departments.SingleOrDefaultAsync(department =>
                    department.DepartmentId == departmentId &&
                    department.Name == dptName &&
                    department.Description == dptDescrription &&
                    department.Active == true));
        }
    }
}
