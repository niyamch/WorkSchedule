using System;
using WorkSchedule.Models.ShiftType;

namespace WorkSchedule.Models.Shift
{
    public class ShiftNameViewModel : ListViewModel
    {
        public ShiftTypeListViewModel Type { get; set; }
        public DateTime Date { get; set; }
        public double MoneyMade { get; set; }
    }
}
