using Ejournal.Application.Common.Helpers.Filters;
using MediatR;


namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkList
{
    public class GetMarkListQuery : IRequest<MarkListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
