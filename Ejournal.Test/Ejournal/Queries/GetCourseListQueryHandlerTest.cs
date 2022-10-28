using Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList;
using Ejournal.Test.Common;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Ejournal.Test.Common.Factories;
using Ejournal.Persistence;
using AutoMapper;

namespace Ejournal.Test.Ejournal.Queries
{
    [Collection("QueryCollection")]
    public class GetCourseListQueryHandlerTest
    {
        private readonly EjournalDbContext context;
        private readonly IMapper mapper;

        public GetCourseListQueryHandlerTest(QueryTestFixture<CourseContextFactory> fixture)
        {
            context = fixture.context;
            mapper = fixture.mapper;
        }

        [Fact]
        public async Task GetCourseListQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetCourseListQueryHandler(context, mapper);

            //Act
            var result = await handler.Handle(
                new GetCourseListQuery { },
                    CancellationToken.None);

            //Assert
            result.ShouldBeOfType<CourseListResponseVm>();
            result.Records.ShouldBe(1);
        }
    }
}
