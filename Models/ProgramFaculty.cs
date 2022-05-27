using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    public class ProgramFaculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? ProgramFacultyId { get; set; }

        // Program Faculty have an Academic Program
        [Required]
        public Int64 AcademicProgramId { get; set; } // n:1 relationship with AcademicProgram
        public AcademicProgram AcademicProgram { get; set; }

        [Required]
        public string FacultyEmail { get; set; }
        
    }
}
