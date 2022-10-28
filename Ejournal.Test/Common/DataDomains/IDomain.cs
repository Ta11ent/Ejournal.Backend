namespace Ejournal.Test.Common.DataDomains
{
    internal interface IDomain<T> where T : class
    {
        T Data { get; }
    }
}
