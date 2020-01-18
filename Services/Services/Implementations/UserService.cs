using DataAccess.Repositories.Interfaces;
using DataAccess.Entities;
using Service.Services.Interfaces;
using System.Linq;

namespace Service.Services.Implementations
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        { }

        public User GetByEmail(string email)
        {
            var user = repository.GetAll(u => u.Email == email).FirstOrDefault();
            return user;
        }
    }
}
