using System;

namespace Ejournal.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found.") { }

        public NotFoundException(string mainName, string dependentName, object key)
            : base($"Dependet \"{dependentName}\" entity ({key}) for main \"{mainName}\" entity not found ") { }

    }
}
