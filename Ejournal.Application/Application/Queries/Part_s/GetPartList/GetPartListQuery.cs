using Ejournal.Application.Common.Helpers.Filters;
using MediatR;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartList
{
    public class GetPartListQuery : IRequest<PartListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
