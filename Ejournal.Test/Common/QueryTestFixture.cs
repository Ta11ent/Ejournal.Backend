using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using Ejournal.Persistence;
using System;
using Xunit;

namespace Ejournal.Test.Common
{
    public class QueryTestFixture<T> : IDisposable where T : ContextFactory, new()
    {
        internal EjournalDbContext context;
        internal IMapper mapper;

        public QueryTestFixture()
        {
            context = ContextFactory.Create();
            new T().FillContext();

            var configurationBuilder = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(
                    typeof(IEjournalDbContext).Assembly));
            });

            mapper = configurationBuilder.CreateMapper();
        }

        public void Dispose() => ContextFactory.Destroy(context);

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture<T>> { }
    }
}
