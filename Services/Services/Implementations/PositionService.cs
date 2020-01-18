using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class PositionService : BaseService<Position>, IPositionService
    {
        public PositionService(IPositionRepository repository) : base(repository)
        { }
    }
}
