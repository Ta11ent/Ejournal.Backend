using Ejournal.Persistence;
using System;

namespace Ejournal.Test.Common
{
    public class CommandTestBase<T> : IDisposable where T : ContextFactory, new()
    {
        protected readonly EjournalDbContext Context;
        internal CommandTestBase()
        {
            Context = ContextFactory.Create();
            Context = new T().GetContext();
        }
        public void Dispose() => ContextFactory.Destroy(Context);
    }
}
