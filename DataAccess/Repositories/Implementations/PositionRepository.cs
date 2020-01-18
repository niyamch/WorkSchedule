using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories.Implementations
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(WorkScheduleContext context) 
            : base(context) { }
    }
}
