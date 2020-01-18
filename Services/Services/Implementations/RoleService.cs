using DataAccess.Repositories.Interfaces;
using DataAccess.Entities;
using Service.Services.Interfaces;
using System.Linq;

namespace Service.Services.Implementations
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(IRoleRepository repository) : base(repository)
        { }

        public Role GetByName(string roleName)
        {
            var role = repository.GetAll(r => r.Name == roleName).FirstOrDefault();
            return role;
        }

    }
}
