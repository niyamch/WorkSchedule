using DataAccess.Entities;

namespace Service.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User GetByEmail(string email);
    }
}
