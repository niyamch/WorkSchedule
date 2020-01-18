using System;
using System.Collections.Generic;
using WorkSchedule.Models.Person;
using WorkSchedule.Models.ShiftType;

namespace WorkSchedule.Models.Shift
{
    public class ShiftListViewModel : ListViewModel
    {
        public ShiftTypeListViewModel Type { get; set; }
        public DateTime Date { get; set; }
        public double MoneyMade { get; set; }
        public ICollection<PersonListViewModel> People { get; set; }
    }
}
