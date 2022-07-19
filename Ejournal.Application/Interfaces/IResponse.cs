using System.Collections.Generic;

namespace Ejournal.Application.Interfaces
{
    public interface IResponse<T> 
    {
        T Data { get; set; }
        bool Succeeded { get; set; }
    }
}
