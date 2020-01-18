using DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        public virtual User User { get; set; }

        public virtual IEnumerable<PersonShift> Shifts { get; set; }
    }
}
