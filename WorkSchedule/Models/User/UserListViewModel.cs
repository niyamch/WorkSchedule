using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSchedule.Models.Person;
using WorkSchedule.Models.Role;

namespace WorkSchedule.Models.User
{
    public class UserListViewModel : ListViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public virtual RoleListViewModel Role { get; set; }
        public int PersonId { get; set; }
        public virtual PersonListViewModel Person { get; set; }
    }
}
