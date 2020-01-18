using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class PersonShiftService : BaseService<PersonShift>, IPersonShiftService
    {
        public PersonShiftService(IPersonShiftRepository repository) : base(repository)
        { }
    }
}
