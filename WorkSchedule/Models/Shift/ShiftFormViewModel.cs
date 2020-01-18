using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.Models.Shift
{
    public class ShiftFormViewModel : FormViewModel
    {
        [Required]
        public int TypeId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double ModeyMade { get; set; }
    }
}
