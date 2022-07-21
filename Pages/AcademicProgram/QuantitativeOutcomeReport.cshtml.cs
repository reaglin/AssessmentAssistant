using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.AcademicProgram
{
    public class QuantitativeOutcomeReport : AAPageModel
    {
        public List<AssessmentAssistant.Models.AcademicCourse>? AcademicCourses { get; set; }

        public List<AssessmentAssistant.Models.ProgramOutcome>? ProgramOutcomes { get; set; }

        public List<AssessmentAssistant.Models.CourseOutcome>? CourseOutcomes { get; set; }

        public List<AssessmentAssistant.Models.OutcomeMeasure>? OutcomeMeasures { get; set; }

        public List<MeasuresTable> MeasurementsTable { get; set; }

        public QuantitativeOutcomeReport(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.AcademicPrograms == null)
            {
                return NotFound();
            }
            programid = id;
           
            var academicprogram = await _context.AcademicPrograms.FirstOrDefaultAsync(m => m.AcademicProgramId == id);
            if (academicprogram == null)
            {
                return NotFound();
            }
            else 
            {
                AcademicProgram = academicprogram;
            }

            measurementperiod = AcademicProgram.MeasurementPeriod;
            // Get all courses for Academic Program
            AcademicCourses = _context.GetAcademicCoursesForProgram(programid, measurementperiod);
            // Get all program outcomes for Academic Program
            ProgramOutcomes = _context.GetProgramOutcomes(programid, measurementperiod);
            // Get all course outcomes for academic program
            CourseOutcomes = _context.GetCourseOutcomesForProgram(programid, measurementperiod);

            MeasurementsTable = _context.GetMeasuresTable(programid, measurementperiod);

            return Page();
        }

        // 
        public string FillCell(AssessmentAssistant.Models.ProgramOutcome po, AssessmentAssistant.Models.AcademicCourse ac)
        {
            return _context.CoversCourseOutcome(po, ac);
        }
    }
}
