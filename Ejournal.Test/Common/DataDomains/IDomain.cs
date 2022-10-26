using System;

namespace Ejournal.Test.Common.DataDomains
{
    internal interface IDomain<T> where T : class
    {
        Guid Id { get; }
        T GetData();
        
    }
}
