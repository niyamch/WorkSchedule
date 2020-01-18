using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.Models.ShiftType
{
    public class ShiftTypeFormViewModel : FormViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}
