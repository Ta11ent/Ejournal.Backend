using System;

namespace Ejournal.Application.Interfaces
{
    public interface IFilterContextParams
    {
        bool? Active { get; set; }
        DateTime? DateFrom { get; set; }
        DateTime? DateTo { get; set; }
        Guid? Group { get; set; }
        Guid? ClassMember { get; set; }
        Guid? Membership { get; set; }
        Guid? Subject { get; set; }
    }
}
