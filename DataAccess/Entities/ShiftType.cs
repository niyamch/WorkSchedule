using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class ShiftType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration
        {
            get
            {
                return this.End - this.Start;
            }
        }

        public virtual IEnumerable<Shift> Shifts { get; set; }
    }
}
