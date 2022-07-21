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

        [Display(Name = "Course (ex. EGN1234)")]
        public string CourseTitle { get; set; }

        [Display(Name = "Course Title")]
        public string? CourseDescription { get; set; }

        [Display(Name = "Course Coordinator Email")]
        public string? CourseCoordinatorID { get; set; }
        public List<CourseOutcome>? CourseOutcomes { get; set; }  // 1:n relationship with Course Outcomes

        [Display(Name = "Academic Program ID")]
        public Int64 AcademicProgramId { get; set; } // n:1 relationship with AcademicProgram
        public AcademicProgram? AcademicProgram { get; set; }    

    }

    public class CourseOutcome: ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64? CourseOutcomeId { get; set; } // CourseIdentifier_OutcomeNumber

        [Display(Name = "Course Outcome Number")]
        public int OutcomeNumber { get; set; }

        [Display(Name = "Course Outcome Statement")]
        public string OutcomeStatement { get; set; }

        [Display(Name = "Associated Program Outcome Number")]
        public int? ProgramOutcomeNumber { get; set; }

        [Display(Name = "Outcome Level")]
        public string? OutcomeLevel { get; set; }

        [Display(Name = "Associated Course Id")]
        public Int64 AcademicCourseId { get; set; } // n:1 relationship with AcademicCourse

        [Display(Name = "Academic Course Actual")]
        public AcademicCourse? AcademicCourse { get; set; }

    }
}
