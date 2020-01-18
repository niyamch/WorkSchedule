using System.Collections.Generic;
using WorkSchedule.Models.User;

namespace WorkSchedule.Models.Role
{
    public class RoleListViewModel : ListViewModel
    {
        public string Name { get; set; }
        public virtual ICollection<UserListViewModel> Users { get; set; }
    }
}
