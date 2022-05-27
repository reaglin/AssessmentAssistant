using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AssessmentAssistant.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssessmentAssistant.Models
{
    public class MeasurementPeriods
    {
        [Key]
        [Display(Name = "MeasurementPeriod")]
        public string MeasurementPeriod { get; set; }
    }

    public class Enumerations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 EnumerationId { get; set; }
        public string Identifier { get; set; } // Use Model and Property
        public string Value { get; set; }
        public int? Order { get; set; }  
        public bool? IsActive { get; set; }


    }
}
