using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class ShiftTypeService : BaseService<ShiftType>, IShiftTypeService
    {
        public ShiftTypeService(IShiftTypeRepository repository) : base(repository)
        { }
    }
}
