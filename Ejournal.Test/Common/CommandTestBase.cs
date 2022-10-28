using Ejournal.Persistence;
using System;

namespace Ejournal.Test.Common
{
    public class CommandTestBase<T> : IDisposable where T : ContextFactory, new()
    {
        protected readonly EjournalDbContext context;
        internal CommandTestBase()
        {
            context = ContextFactory.Create();
            new T().FillContext();
        }
        public void Dispose() => ContextFactory.Destroy(context);
    }
}
