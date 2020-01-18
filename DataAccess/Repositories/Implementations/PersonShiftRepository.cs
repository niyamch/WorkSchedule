using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementations
{
    public class PersonShiftRepository : Repository<PersonShift>, IPersonShiftRepository
    {
        public PersonShiftRepository(WorkScheduleContext context)
            : base(context) { }
    }
}
