using Ejournal.Persistence;
using System;

namespace Ejournal.Test.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly EjournalDbContext Context;
        public TestCommandBase() => Context = ContextFactory.Create();
        public void Dispose() => ContextFactory.Destroy(Context);
    }
}
