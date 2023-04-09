using paySimplex.Domain.DTOs;
using paySimplex.Domain.Enums;

namespace paySimplex.Domain.Interfaces.Services
{
    public interface IChoreService
    {
        IList<ChoreDTO> GetAll(int? userId, Status? status, DateTime? startDate, DateTime? endDate);
        IList<ChoreDTO> GetByUserId(int userId);
        ChoreDTO GetById(int id);
        void Insert(ChoreDTO chore);
        void Update(ChoreDTO chore, int id);
        void Delete(int id);
        void ChangeStatus(Status status, int id);
    }
}
