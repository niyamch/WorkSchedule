using DataAccess.Entities;

namespace Service.Services.Interfaces
{
    public interface IRoleService : IBaseService<Role>
    {
        Role GetByName(string roleName);
    }
}
