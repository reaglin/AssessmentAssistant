using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    public class CourseOffering :ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CourseOfferingId { get; set; } // Course_Semester_Section
        [Display (Name="Section (optional)")]
        public string? SectionNumber { get; set; }

        [Display(Name = "Semester")]
        public string? Semester { get; set; }

        [Display(Name = "Instructor")]
        public string? Instructor { get; set; } // denote using the Instructor ID (email)

        public Int64 AcademicCourseId { get; set; } // n:1 with AcademicCourse
        public AcademicCourse? AcademicCourse { get; set; }

        [Display(Name = "A")]
        public int? Number_A { get; set; }

        [Display(Name = "B")]
        public int? Number_B { get; set; }

        [Display(Name = "C")]
        public int? Number_C { get; set; }

        [Display(Name = "D")]
        public int? Number_D { get; set; }

        [Display(Name = "F")]
        public int? Number_F { get; set; }

        [Display(Name = "W")]
        public int? Number_W { get; set; }

        [Display(Name = "Issues Faced")]
        public string? IssuesFaced { get; set; }

        [Display(Name = "Proposed Improvements")]
        public string? ProposedImprovements { get; set; }

        [Display(Name = "Results of Improvements")]
        public string? ResultsOfImprovements { get; set; }

        public List<OutcomeMeasure>? OutcomeMeasures { get; set;} // 1:n OutcomeMeasure 

    }

    public class OutcomeMeasure: ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 OutcomeMeasureId { get; set; }

        [Display(Name = "Course Outcome #")]
        public int? CourseOutcomeNumber { get; set; }

        [Display(Name = "Assessment Type")]
        public string? AssessmentType { get; set; }

        [Display(Name = "Measurement")]
        public string? MeasurementStatement { get; set; }

        [Display(Name = "Threshold (%)")]
        public int? ThresholdValue { get; set; }

        [Display(Name = "Number Measured")]
        public int? NumberMeasured { get; set; }

        [Display(Name = "Number > Threshold")]
        public int? NumberMeetingThreshold { get; set; }

        public Int64? CourseOfferingId { get; set; }  //n:1 CourseOffering
        public CourseOffering? CourseOffering { get; set; } 

    }
}
