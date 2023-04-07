using paySimplex.Domain.DTOs;

namespace paySimplex.Domain.Interfaces.Services
{
    public interface IChoreService
    {
        IList<ChoreDTO> GetAll();
        ChoreDTO GetById(int id);
        void Insert(ChoreDTO chore);
        void Update(ChoreDTO chore, int id);
        void Delete(int id);
    }
}
