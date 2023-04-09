using paySimplex.Domain.DTOs;
using paySimplex.Domain.Enums;
using paySimplex.Domain.Exceptions;
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
            {
                query = query.Where(c => c.UserId == userId);
                if (query == null)
                   throw new EntityNotFoundException($"User number {userId} not found");
            }

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
            IEnumerable<Chore> data = _choreRepository.GetByUserId(userId);

            if (data == null)
                throw new EntityNotFoundException($"User number {userId} not found");

            return data
                .Select(c => new ChoreDTO(c))
                .ToList();
        }

        public ChoreDTO GetById(int id)
        {
            Chore data = _choreRepository.GetById(id);

            if (data == null)
                throw new EntityNotFoundException($"Chore number {id} not found");

            return new ChoreDTO(data);
        }

        public void Insert(ChoreDTO choreDTO)
        {
            if (InvalidFileSize(choreDTO.File))
                throw new InvalidFileSizeException("File to large for this operation");

            if (InvalidStartEndDate(choreDTO.StartDate, choreDTO.EndDate))
                throw new InvalidStartEndDateException("Invalid date: Start date is set after end date");

            Chore data = new(choreDTO);

            _choreRepository.Insert(data);
        }

        public void Update(ChoreDTO choreDTO, int id)
        {
            Chore chore = _choreRepository.GetById(id);

            if (chore == null)
                throw new EntityNotFoundException($"Chore number {id} not found");

            if (InvalidStartEndDate(choreDTO.StartDate, choreDTO.EndDate))
                throw new InvalidStartEndDateException("Invalid date: Start date is set after end date");

            chore.Name = choreDTO.Name;
            chore.StartDate = choreDTO.StartDate ??= DateTime.Now;
            chore.EndDate = choreDTO.EndDate;
            chore.Status = choreDTO.Status;

            if (InvalidFileSize(choreDTO.File))
                throw new InvalidFileSizeException("File to large for this operation");

            chore.File = choreDTO.File;


            _choreRepository.Update(chore);
        }

        public void Delete(int id)
        {
            Chore data = _choreRepository.GetById(id);

            if (data == null)
                throw new EntityNotFoundException($"Chore {id} not found");

            _choreRepository.Delete(data);
        }

        public void ChangeStatus(Status status, int id)
        {
            Chore chore = _choreRepository.GetById(id);

            chore.Status = status;

            if ((int)status == 2)
            {
                // As the endpoint sets the task as finished it also changes its end date
                chore.EndDate = DateTime.Now;
            }

            _choreRepository.Update(chore);
        }

        public TimeSpan TimeInProgress(int id)
        {
            Chore data = _choreRepository.GetById(id);

            TimeSpan timeInProgress = (data.EndDate - data.StartDate);

            return timeInProgress;
        }


        private static bool InvalidFileSize(string b64)
        {
            if (String.IsNullOrEmpty(b64))
                return false;

            var fileSize = b64.Length;
            var maxByteSize = 5000000; // 5MB

            return fileSize > maxByteSize;
        }

        private static bool InvalidStartEndDate(DateTime? startDate, DateTime endDate)
        {
            return (startDate ?? DateTime.Now) > endDate;
        }
    }
}
