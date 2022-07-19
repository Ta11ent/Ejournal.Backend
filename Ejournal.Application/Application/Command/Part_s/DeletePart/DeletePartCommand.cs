using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Part_s.DeletePart
{
    public class DeletePartCommand : IRequest
    {
        public Guid PartId { get; set; }
    }
}
