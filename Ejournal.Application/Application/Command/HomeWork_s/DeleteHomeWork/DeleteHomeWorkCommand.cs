using MediatR;
using System;

namespace Ejournal.Application.Application.Command.HomeWork_s.DeleteHomeWork
{
    public class DeleteHomeWorkCommand : IRequest
    {
        public Guid HomeWorkId { get; set; }
    }
}
