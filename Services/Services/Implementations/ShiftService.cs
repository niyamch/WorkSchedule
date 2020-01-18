using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class ShiftService : BaseService<Shift> , IShiftService
    {
        public ShiftService(IShiftRepository repository) : base(repository)
        { }
    }
}
