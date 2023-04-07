using paySimplex.Domain.Enums;
using paySimplex.Domain.Models;

namespace paySimplex.Domain.DTOs
{
    public class ChoreDTO
    {
        public int Id { get; internal set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public ChoreDTO()
        {
        }

        public ChoreDTO(Chore chore)
        {
            Id = chore.Id;
            UserId = chore.UserId;
            Name = chore.Name;
            StartDate = chore.StartDate;
            EndDate = chore.EndDate;
            Status = chore.Status;
        }
    }
}
