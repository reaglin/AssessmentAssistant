using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseOffering
{
    public class DetailsModel : AAPageModel
    {

        public DetailsModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.CourseOffering CourseOffering { get; set; } = default!; 
      public List<AssessmentAssistant.Models.CourseOutcome> CourseOutcomes { get; set; }   

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.CourseOfferings == null)
            {
                return NotFound();
            }

            var courseoffering = await _context.CourseOfferings.FirstOrDefaultAsync(m => m.CourseOfferingId == id);

            if (courseoffering == null)
            {
                return NotFound();
            }
            else 
            {
                offeringid = id;
                courseid = courseoffering.AcademicCourseId;
                measurementperiod = this.MeasurementPeriod();

                CourseOffering = courseoffering;
                CourseOutcomes = _context.GetCourseOutcomes(courseid, measurementperiod);
            }
            return Page();
        }

        public string NumberMeasures(int co)
        {
            List<AssessmentAssistant.Models.OutcomeMeasure> om = _context.GetOutcomeMeasuresForCourseOfferingAndOutcomeNumber(offeringid, co, measurementperiod);
            return om.Count().ToString();
        }
    }
}
