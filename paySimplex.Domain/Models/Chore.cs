using paySimplex.Domain.DTOs;
using paySimplex.Domain.Enums;

namespace paySimplex.Domain.Models
{
    public class Chore
    {
        public int Id { get; internal set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public string? File { get; set; }

        public virtual User User { get; set; }
        public Chore()
        {
        }
        public Chore(ChoreDTO choreDTO)
        {
            Id = choreDTO.Id;
            UserId = choreDTO.UserId;
            Name = choreDTO.Name;
            StartDate = choreDTO.StartDate;
            EndDate = choreDTO.EndDate;
            Status = choreDTO.Status;
        }
    }
}
