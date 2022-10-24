using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using Ejournal.Persistence;
using System;
using Xunit;

namespace Ejournal.Test.Common
{
    public class QueryTestFixture : IDisposable
    {
        internal EjournalDbContext Context;
        internal IMapper Mapper;

        public QueryTestFixture()
        {
            Context = ContextFactory.Create();
            var configurationBuilder = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(
                    typeof(IEjournalDbContext).Assembly));
            });

            Mapper = configurationBuilder.CreateMapper();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }

        [CollectionDefinition("QueryCollection")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
}
