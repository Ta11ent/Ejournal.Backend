using System;

namespace Ejournal.Application.Interfaces
{
    public interface IFilterContextParams
    {
        bool? Active { get; set; }
        DateTime? DateFrom { get; set; }
        DateTime? DateTo { get; set; }
        Guid? Group { get; set; }
        Guid? GroupMember { get; set; }
        Guid? DepartmentMember { get; set; }
        Guid? Subject { get; set; }
    }
}
