using paySimplex.Domain.Interfaces.Repositories;
using paySimplex.Domain.Models;

namespace paySimplex.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(PaySimplexDbContext context) : base(context)
        {
        }
    }
}
