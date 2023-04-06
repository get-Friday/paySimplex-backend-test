using paySimplex.Domain.Enums;

namespace paySimplex.Domain.Models
{
    internal class Chore
    {
        public int Id { get; internal set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public Chore()
        {
        }
    }
}
