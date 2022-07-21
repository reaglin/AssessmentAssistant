using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.AcademicCourse
{
    public class FCEReportModel : AAPageModel
    {

        public FCEReportModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.AcademicCourse AcademicCourse { get; set; } = default!; 

        public List<AssessmentAssistant.Models.CourseOffering> CourseOfferings { get; set; } = default!;

        public List<AssessmentAssistant.Models.CourseOutcome> CourseOutcomes { get; set; }

        public List<AssessmentAssistant.Models.OutcomeMeasure> OutcomeMeasures { get; set; }


        public Dictionary<string, int> Grades = AssessmentAssistant.Models.TablesForReports.GradesDictionary();

        public Dictionary<string, AssessmentAssistant.Models.MeasuresTable> MeasurementsDictionary = AssessmentAssistant.Models.TablesForReports.MeasuresDictionary();
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            
            if (id == null || _context.AcademicCourses == null)
            {
                return NotFound();
            }

            courseid = id;
            measurementperiod = MeasurementPeriod();

            CourseOfferings = _context.GetCourseOfferings(courseid, measurementperiod);
            TablesForReports.FillGrades(CourseOfferings, Grades);

            CourseOutcomes = _context.GetCourseOutcomes(courseid, measurementperiod);

            OutcomeMeasures = _context.GetOutcomeMeasuresForCourseOffering(CourseOfferings[0].CourseOfferingId, measurementperiod);

            MeasurementsDictionary = TablesForReports.FillMeasuresDictionary(measurementperiod, (long)courseid, CourseOutcomes, CourseOfferings, OutcomeMeasures);
            
            var academiccourse = await _context.AcademicCourses.FirstOrDefaultAsync(m => m.AcademicCourseId == id);
            if (academiccourse == null)
            {
                return NotFound();
            }
            else 
            {
                AcademicCourse = academiccourse;
            }
            return Page();
        }





    }
}
