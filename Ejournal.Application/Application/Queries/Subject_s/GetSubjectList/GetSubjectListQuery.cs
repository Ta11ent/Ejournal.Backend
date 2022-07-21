using Ejournal.Application.Common.Helpers.Filters;
using MediatR;

namespace Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectList
{
    public class GetSubjectListQuery : IRequest<SubjectListResponseVm>
    {
        public PaginationParams Parametrs { get; set; }
    }
}
