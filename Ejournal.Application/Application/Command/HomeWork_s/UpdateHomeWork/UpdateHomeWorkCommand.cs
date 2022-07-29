using MediatR;
using System;

namespace Ejournal.Application.Application.Command.HomeWork_s.UpdateHomeWork
{
    public class UpdateHomeWorkCommand : IRequest
    {
        public Guid HomeWorkId { get; set; }
        public DateTime Date { get; set; }
        public string Description {get;set;}
        public Guid GroupId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
