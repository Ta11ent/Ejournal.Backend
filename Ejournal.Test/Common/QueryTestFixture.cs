using AutoMapper;
using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using Ejournal.Persistence;
using Ejournal.Test.Common.Factories;
using System;
using Xunit;

namespace Ejournal.Test.Common
{
    public class QueryTestFixture<T> : IDisposable where T : ContextFactory, new()
    {
        protected readonly EjournalDbContext context;
        protected readonly IMapper mapper;

        public QueryTestFixture()
        {
            context = ContextFactory.Create();
            new T().FillContext(context);

            var configurationBuilder = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(
                    typeof(IEjournalDbContext).Assembly));
            });
            mapper = configurationBuilder.CreateMapper();
        }

        public void Dispose() => ContextFactory.Destroy(context);

        //[CollectionDefinition("QueryCollection")]
        //public class QueryCollection : ICollectionFixture<QueryTestFixture<ContextFactory>> { }
    }
}
