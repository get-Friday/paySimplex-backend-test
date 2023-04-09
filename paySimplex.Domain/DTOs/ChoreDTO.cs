using paySimplex.Domain.Enums;
using paySimplex.Domain.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace paySimplex.Domain.DTOs
{
    public class ChoreDTO
    {
        public int Id { get; internal set; }
        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Chore name is required")]
        [MaxLength(300)]
        public string Name { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date must be valid")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date, ErrorMessage = "Date must be valid")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        [DefaultValue(0)]
        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }
        public string? File { get; set; }

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
