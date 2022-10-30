using AutoMapper;
using Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseDetails;
using Ejournal.Persistence;
using Ejournal.Test.Common;
using Ejournal.Test.Common.DataDomains;
using Ejournal.Test.Common.Factories;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Ejournal.Test.Ejournal.Queries.Course
{
    //[Collection("QueryCollection")]
    public class GetCourseDetailsQueryHandlerTest : QueryTestFixture<CourseContextFactory>
    {
        //private readonly EjournalDbContext context;
        //private readonly IMapper mapper;

        //public GetCourseDetailsQueryHandlerTest(QueryTestFixture<CourseContextFactory> fixture)
        //{
        //    context = fixture.context;
        //    mapper = fixture.mapper;
        //}

        [Fact]
        public async Task GetCourseDetailsQueryHandler_Succes()
        {
            //Arrange
            var handler = new GetCourseDetailsQueryHandler(context, mapper);
            var course = new DataCourse(ContextFactory.IdForDelete);
            course.Create();

            //Act
            var result = await handler.Handle(
                    new GetCourseDetailsQuery
                    {
                        CourseId = course.Data.CourseId
                    },
                    CancellationToken.None
                );
            result.ShouldBeOfType<CourseDetailsResponseVm>();
            result.Data.Name.ShouldBe(course.Data.Name);
            result.Data.Active.ShouldBe(course.Data.Active);
        }
    }
}
