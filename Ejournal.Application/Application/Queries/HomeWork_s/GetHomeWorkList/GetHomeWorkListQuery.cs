using Ejournal.Application.Common.Helpers.Filters;
using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkList
{
    public class GetHomeWorkListQuery : IRequest<HomeWorkListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
