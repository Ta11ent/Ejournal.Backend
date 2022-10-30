using Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList;
using Ejournal.Test.Common;
using System.Threading;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using Ejournal.Test.Common.Factories;
using Ejournal.Application.Common.Helpers.Filters;

namespace Ejournal.Test.Ejournal.Queries.Course
{
    //[Collection("QueryCollection")]
    public class GetCourseListQueryHandlerTest : QueryTestFixture<CourseContextFactory>
    {
        //private readonly EjournalDbContext context;
        //private readonly IMapper mapper;

        //public GetCourseListQueryHandlerTest(QueryTestFixture<CourseContextFactory> fixture)
        //{
        //    context = fixture.context;
        //    mapper = fixture.mapper;
        //}

        [Fact]
        public async Task GetCourseListQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetCourseListQueryHandler(context, mapper);

            //Act
            var result = await handler.Handle(
                new GetCourseListQuery() {
                    Parametrs = new FilterParams()
                },
                    CancellationToken.None);

            //Assert
            result.ShouldBeOfType<CourseListResponseVm>();
            result.Records.ShouldBe(3);
        }

        [Fact]
        public async Task GetCourseFilteredListQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetCourseListQueryHandler(context, mapper);

            //Act
            var result = await handler.Handle(
                new GetCourseListQuery()
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
            result.ShouldBeOfType<CourseListResponseVm>();
            result.Records.ShouldBe(1);
        }
    }
}
