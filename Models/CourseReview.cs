using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    // Overall Review of a course
    public class CourseReview : ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CourseReviewId { get; set; } 
  
        [Display(Name = "Course Offering Reviewed Id")]
        public int CourseOfferingReviewedId { get; set; }

        public CourseOffering? CourseOffering { get; set; }

        [Display(Name = "Course Review Statement")]
        public string? CourseReviewStatement { get; set; }

        [Display(Name = "Reviewed By User")]
        public string? ReviewedByUserName { get; set; }
    }

    // Allows for reviews of course offerings using the standards
    // A review would exist for each standard for each offering of a course 
    // being reviewed
    public class CourseStandardsReview : ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CourseStandardsReviewId { get; set; }

        public string? ReviewStatement { get; set; }

        public string? ReviewResponse { get; set; } 

        public int? PointsAssigned { get; set; }    

        // Standard being reviewed
        public Int64 CourseReviewStandardsId { get; set; }

        public CourseReviewStandards? CourseReviewStandard { get; set; }

        public string? ReviewedByUserName { get; set; }
    }


    // Each of the individual standards used to review a course. 
    public class CourseReviewStandards : ApplicationAssistantAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CourseReviewStandardsId { get; set; }

        public int? GeneralStandardVersion { get; set; }

        public int GeneralStandardNumber { get; set; }

        public string? GeneralStandard { get; set; }

        public int? ReviewStandardNumber { get; set; }

        public string? ReviewStandard { get; set; }

        public int? ReviewStandardPoints { get; set; }
    }

}
