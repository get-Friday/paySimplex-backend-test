using paySimplex.Domain.Interfaces.Repositories;
using paySimplex.Domain.Models;

namespace paySimplex.Infra.Data.Repositories
{
    public class ChoreRepository : BaseRepository<Chore, int>, IChoreRepository
    {
        public ChoreRepository(PaySimplexDbContext context) : base(context)
        {
        }
    }
}
