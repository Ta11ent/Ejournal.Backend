using MediatR;
using System;

namespace Ejournal.Application.Application.Command.Goup_s.DeleteGroup
{
    public class DeleteGroupCommand : IRequest
    {
        public Guid GroupId { get; set; }
    }
}
