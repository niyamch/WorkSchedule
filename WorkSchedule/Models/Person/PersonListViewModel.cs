using System;
using WorkSchedule.Models.Position;
using WorkSchedule.Models.Shift;
using System.Collections.Generic;

namespace WorkSchedule.Models.Person
{
    public class PersonListViewModel : ListViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PositionListViewModel Position { get; set; }
        public ICollection<ShiftListViewModel> Shifts { get; set; }
    }
}
