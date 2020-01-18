using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementations
{
    public class ShiftRepository : Repository<Shift>, IShiftRepository
    {
        public ShiftRepository(WorkScheduleContext context)
            : base(context) { }
    }
}
