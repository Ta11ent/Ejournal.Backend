using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Ejournal.Command.Department_s.UpdateDepartment;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.Department
{
    public class UpdateDepartmentCommandHandlerTest : CommandTestBase<DepartmentContextFactory>
    {
        [Fact]
        public async Task DeleteDepartmetnCommandHandler_Succes()
        {
            //Arrange
            var handler = new UpdateDepartmentCommandHandler(context);
            var uptName = "Test Name Update";
            var uptDescripton = "Test Description Update";
            var active = false;

            //Act
            await handler.Handle(new UpdateDepartmentCommand
            {
                DepartmentId = ContextFactory.IdForUpdate,
                Name = uptName,
                Description = uptDescripton,
                Active = active
            },
            CancellationToken.None);

            //Assert
            Assert.NotNull(
                await context.Departments.SingleOrDefaultAsync(department =>
                    department.DepartmentId == ContextFactory.IdForUpdate &&
                    department.Name == uptName &&
                    department.Description == uptDescripton &&
                    department.Active == active));
        }

        [Fact]
        public async Task UpdateDepartmentCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new UpdateDepartmentCommandHandler(context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                       new UpdateDepartmentCommand
                       {
                           DepartmentId = Guid.NewGuid()
                       },
                        CancellationToken.None));
        }
    }
}
