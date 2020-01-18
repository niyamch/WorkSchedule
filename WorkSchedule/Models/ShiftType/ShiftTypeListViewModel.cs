using System;
using System.Collections.Generic;
using WorkSchedule.Models.Shift;

namespace WorkSchedule.Models.ShiftType
{
    public class ShiftTypeListViewModel : ListViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<ShiftListViewModel> Shifts { get; set; }
    }
}
