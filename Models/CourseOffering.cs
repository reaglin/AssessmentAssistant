using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    public class CourseOffering :ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CourseOfferingId { get; set; } // Course_Semester_Section
        public string? SectionNumber { get; set; }
        public string? Semester { get; set; }
        public string? Instructor { get; set; }

        public Int64 AcademicCourseId { get; set; } // n:1 with AcademicCourse
        public AcademicCourse AcademicCourse { get; set; }

        public int? Number_A { get; set; }   
        public int? Number_B { get; set; }
        public int? Number_C { get; set; }
        public int? Number_D { get; set; }
        public int? Number_F { get; set; }
        public int? Number_W { get; set; }

        public List<OutcomeMeasure>? OutcomeMeasures { get; set;} // 1:n OutcomeMeasure 

    }

    public class OutcomeMeasure: ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 OutcomeMeasureId { get; set; }
        public CourseOutcome CourseOutcome { get; set; } 
        
        public string? AssessmentType { get; set; }

        public string? MeasurementStatement { get; set; }

        public int? ThresholdValue { get; set; }

        public int? NumberMeasured { get; set; }

        public int? NumberMeetingThreshold { get; set; }

        public Int64? CourseOfferingId { get; set; }  //n:1 CourseOffering
        public CourseOffering? CourseOffering { get; set; } 

    }
}
