using paySimplex.Domain.Models;

namespace paySimplex.Domain.Interfaces.Repositories
{
    internal interface IChoreRepository : IBaseRepository<Chore, int>
    {
        IEnumerable<Chore> GetByUserId(int userId);
    }
}
