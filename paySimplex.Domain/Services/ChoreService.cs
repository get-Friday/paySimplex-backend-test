using paySimplex.Domain.DTOs;
using paySimplex.Domain.Interfaces.Repositories;
using paySimplex.Domain.Interfaces.Services;

namespace paySimplex.Domain.Services
{
    internal class ChoreService : IChoreService
    {
        private readonly IChoreRepository _choreRepository;
        public ChoreService(IChoreRepository choreRepository)
        {
            _choreRepository = choreRepository;
        }

        public IList<ChoreDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ChoreDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ChoreDTO choreDTO)
        {
            throw new NotImplementedException();
        }

        public void Update(ChoreDTO choreDTO, int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
