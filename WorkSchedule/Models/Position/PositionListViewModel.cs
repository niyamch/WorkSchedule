using System.Collections.Generic;
using WorkSchedule.Models.Person;

namespace WorkSchedule.Models.Position
{
    public class PositionListViewModel : ListViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PersonListViewModel> People { get; set; }
    }
}
