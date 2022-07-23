using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkList
{
    public class MarkLookupDto : IMapWith<Mark>
    {
        public Guid MarkId { get; set; }
        public string Name { get; set; }
    }
}
