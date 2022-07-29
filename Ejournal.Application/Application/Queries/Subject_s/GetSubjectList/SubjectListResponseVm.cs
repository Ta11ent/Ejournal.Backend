using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectList
{
    public class SubjectListResponseVm : PageResponse<List<SubjectLookupDto>>
    {
        public SubjectListResponseVm(List<SubjectLookupDto> data, IPaginationParams parametrs)
            : base(data, parametrs) { }
    }
}
