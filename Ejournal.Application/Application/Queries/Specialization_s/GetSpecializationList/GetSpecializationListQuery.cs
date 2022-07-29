using Ejournal.Application.Common.Helpers.Filters;
using MediatR;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationList
{
    public class GetSpecializationListQuery : IRequest<SpecializationListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
