using Ejournal.Application.Common.Helpers.Filters;
using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartList
{
    public class GetPartListQuery : IRequest<PartListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
       // public Guid PartId { get; set; }
    }
}
