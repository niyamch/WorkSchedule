using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<Person> People { get; set; }
    }
}
