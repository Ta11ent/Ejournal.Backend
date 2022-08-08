using System;
using System.Collections.Generic;

namespace Ejournal.Domain
{
    public class Mark
    {
        public Guid MarkId { get; set; }
        public string Name { get; set; }

        public IEnumerable<RatingLog> RatingLog { get; set; }
    }
}
