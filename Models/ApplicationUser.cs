using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AssessmentAssistant.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Preferred Display Name")]
        public string? UserDisplayName { get; set; }

        [Display(Name = "Additional Information")]
        [DataType(DataType.MultilineText)]
        public string? UserComments { get; set; }
    }
}
