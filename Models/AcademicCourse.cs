using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    public class AcademicCourse : ApplicationAssistantAbstract
    {
        // Defined by a prefix and a number
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? AcademicCourseId { get; set; }
        public string CourseTitle { get; set; } 
        public string? CourseDescription { get; set; }   
        public string CourseCoordinatorID { get; set; }
        public List<CourseOutcome> CourseOutcomes { get; set; }  // 1:n relationship with Course Outcomes

        public Int64 AcademicProgramId { get; set; } // n:1 relationship with AcademicProgram
        public AcademicProgram AcademicProgram { get; set; }    

    }

    public class CourseOutcome: ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? CourseOutcomeId { get; set; } // CourseIdentifier_OutcomeNumber
        public int OutcomeNumber { get; set; }
        public string OutcomeStatement { get; set; }

        public int? ProgramOutcomeNumber { get; set; }
        public string? OutcomeLevel { get; set; }

        public Int64? AcademicCourseId { get; set; } // n:1 relationship with AcademicCourse
        public AcademicCourse? AcademicCourse { get; set; }

    }
}
