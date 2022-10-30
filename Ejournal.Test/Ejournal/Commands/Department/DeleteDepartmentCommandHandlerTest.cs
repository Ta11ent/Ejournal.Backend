using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Ejournal.Command.Department_s.DeleteDepartment;
using Ejournal.Test.Common;
using Ejournal.Test.Common.Factories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Commands.Department
{
    public class DeleteDepartmentCommandHandlerTest : CommandTestBase<DepartmentContextFactory>
    {
        [Fact]
        public async Task DeleteDepartmenrCommandHandler_Succes()
        {
            //Arrange
            var handler = new DeleteDepartmentCommandHandler(context);

            //Act
            await handler.Handle(
                    new DeleteDepartmentCommand
                    {
                        DepartmentId = ContextFactory.IdForDelete
                    },
                    CancellationToken.None
                );

            //Assert
            Assert.Null(context.Departments.SingleOrDefault(course =>
                course.DepartmentId == ContextFactory.IdForDelete));
        }

        [Fact]
        public async Task DeleteDepartmentCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteDepartmentCommandHandler(context);

            //Act
            
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteDepartmentCommand
                    {
                        DepartmentId = Guid.NewGuid()
                    },
                    CancellationToken.None)
            );
        }
    }
}
