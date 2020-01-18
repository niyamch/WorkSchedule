using System.ComponentModel.DataAnnotations;

namespace WorkSchedule.Models.Position
{
    public class PositionFormViewModel : FormViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
