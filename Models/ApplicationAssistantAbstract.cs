using AssessmentAssistant.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    public abstract class ApplicationAssistantAbstract
    {
        [Display(Name = "Measurement Period")]
        public string MeasurementPeriod { get; set; }


    }
}
