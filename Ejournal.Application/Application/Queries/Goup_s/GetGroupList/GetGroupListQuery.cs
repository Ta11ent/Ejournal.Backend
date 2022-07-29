using Ejournal.Application.Common.Helpers.Filters;
using MediatR;


namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupList
{
    public class GetGroupListQuery : IRequest<GroupListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
