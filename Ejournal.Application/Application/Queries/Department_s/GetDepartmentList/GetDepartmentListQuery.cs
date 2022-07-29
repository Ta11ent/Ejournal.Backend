using Ejournal.Application.Common.Helpers.Filters;
using MediatR;

namespace Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList
{
    public class GetDepartmentListQuery : IRequest<DepartmentListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}