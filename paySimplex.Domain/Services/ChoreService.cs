using paySimplex.Domain.DTOs;
using paySimplex.Domain.Enums;
using paySimplex.Domain.Interfaces.Repositories;
using paySimplex.Domain.Interfaces.Services;
using paySimplex.Domain.Models;

namespace paySimplex.Domain.Services
{
    internal class ChoreService : IChoreService
    {
        private readonly IChoreRepository _choreRepository;
        public ChoreService(IChoreRepository choreRepository)
        {
            _choreRepository = choreRepository;
        }

        public IList<ChoreDTO> GetAll(int? userId, Status? status, DateTime? startDate, DateTime? endDate)
        {
            IQueryable<Chore> query = _choreRepository.GetAll();

            if (userId.HasValue)
                query = query.Where(c => c.UserId == userId);

            if (status.HasValue)
                query = query.Where(c => c.Status == status);

            if (startDate.HasValue)
                query = query.Where(c => c.StartDate == startDate);

            if(endDate.HasValue)
                query = query.Where(c => c.EndDate == endDate);

            return query
                .Select(c => new ChoreDTO(c))
                .ToList();
        }

        public IList<ChoreDTO> GetByUserId(int userId)
        {
            return _choreRepository
                .GetByUserId(userId)
                .Select(c => new ChoreDTO(c))
                .ToList();
        }

        public ChoreDTO GetById(int id)
        {
            Chore data = _choreRepository.GetById(id);

            return new ChoreDTO(data);
        }

        public void Insert(ChoreDTO choreDTO)
        {
            if (InvalidFileSize(choreDTO.File))
                throw new Exception();

            Chore data = new(choreDTO);



            _choreRepository.Insert(data);
        }

        public void Update(ChoreDTO choreDTO, int id)
        {
            Chore chore = _choreRepository.GetById(id);

            chore.Name = choreDTO.Name;
            chore.StartDate = choreDTO.StartDate;
            chore.EndDate = choreDTO.EndDate;
            chore.Status = choreDTO.Status;

            _choreRepository.Update(chore);
        }

        public void Delete(int id)
        {
            Chore data = _choreRepository.GetById(id);

            _choreRepository.Delete(data);
        }


        public bool InvalidFileSize(string b64)
        {
            var fileSize = b64.Length;
            var maxByteSize = 5000000; // 5MB

            return fileSize > maxByteSize;
        }
    }
}
