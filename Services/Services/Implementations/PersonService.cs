using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IPersonRepository repository) : base(repository)
        { }
    }
}
