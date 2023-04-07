using System.ComponentModel.DataAnnotations;

namespace paySimplex.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Scheduled")]
        Scheduled,
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Done")]
        Done
    }
}
