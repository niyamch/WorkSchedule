using System;
using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.Models.Person
{
    public class PersonFormViewModel : FormViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int PositionId { get; set; }
    }
}
