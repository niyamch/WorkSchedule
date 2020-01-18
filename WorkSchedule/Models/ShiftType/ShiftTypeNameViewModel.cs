using System;

namespace WorkSchedule.Models.ShiftType
{
    public class ShiftTypeNameViewModel : ListViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
