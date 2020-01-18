using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementations
{
    public class ShiftTypeRepository : Repository<ShiftType>, IShiftTypeRepository
    {
        public ShiftTypeRepository(WorkScheduleContext context)
            : base(context) { }
    }
}
