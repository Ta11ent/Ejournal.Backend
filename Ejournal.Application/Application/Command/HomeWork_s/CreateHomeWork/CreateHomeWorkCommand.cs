using MediatR;
using System;

namespace Ejournal.Application.Application.Command.HomeWork_s.CreateHomeWork
{
    public class CreateHomeWorkCommand : IRequest<Guid>
    {
        public DateTime Data { get; set; }
        public string Description { get; set; }
        public Guid GroupId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
