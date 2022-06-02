using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    // When using the program certain items should be considered Global
    // We typically only work in one MeasurementPeriod - so we should only see 
    // items from that measurement Period

    // Also most users only work on one Academic Program at a time - so all 
    // items should pertain to that Academic Program

    public class UserSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? UserSettingsId { get; set; }

        [Required]
        [Display(Name = "User for Settings Email")]
        public string? UserId { get; set; }

        [Display(Name = "Measurement Period")]
        public string? MeasurementPeriod { get; set; }

        [Display(Name = "Academic Program ID")]
        public Int64? AcademicProgramId { get; set; } // n:1 relationship with AcademicProgram
    }
}
