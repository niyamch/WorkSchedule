using System;
using WorkSchedule.Models.Position;

namespace WorkSchedule.Models.Person
{
    public class PersonNameViewModel : ListViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PositionListViewModel Position { get; set; }
    }
}
