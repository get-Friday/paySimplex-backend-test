using System.ComponentModel.DataAnnotations;

namespace paySimplex.Domain.Enums
{
    internal enum Status
    {
        [Display(Name = "Scheduled")]
        Scheduled,
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "Done")]
        Done
    }
}
