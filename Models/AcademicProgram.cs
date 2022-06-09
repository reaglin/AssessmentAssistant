using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    public class AcademicProgram : ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 AcademicProgramId { get; set; }

        [Display (Name="Program Title")]
        public string ProgramTitle { get; set; }

        [Display(Name = "Program Description")]
        public string? ProgramDescription { get; set; }

        [Display(Name = "Program Outcomes")]
        public List<ProgramOutcome>? ProgramOutcomes { get; set; }  // 1:n with ProgramOutcomes
       
        [Display(Name = "Program Courses")]
        public List<AcademicCourse>? AcademicCourses { get; set; }   // 1:n with AcademicCourses

    }

    public class ProgramOutcome : ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ProgramOutcomeId { get; set; }

        [Display(Name = "Outcome Number")]
        public int OutcomeNumber { get; set; }

        [Display(Name = "Outcome Statement")]
        public string OutcomeStatement { get; set; }
        
        public Int64 AcademicProgramId { get; set; }  // n:1 with AcademicProgram
        public AcademicProgram? AcademicProgram { get; set; }


    }
}
