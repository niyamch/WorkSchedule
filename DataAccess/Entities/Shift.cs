using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Shift : BaseEntity
    {
        public int TypeId { get; set; }
        public virtual ShiftType Type { get; set; }
        public DateTime Date { get; set; }
        public double MoneyMade { get; set; }

        public virtual IEnumerable<PersonShift> People { get; set; }
    }
}
