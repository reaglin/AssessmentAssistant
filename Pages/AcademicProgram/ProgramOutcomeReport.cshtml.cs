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
    public class ProgramOutcomeReportModel : AAPageModel
    {
        public List<AssessmentAssistant.Models.ProgramOutcome> ProgramOutcomes { get; set; }
        public List<AssessmentAssistant.Models.AcademicCourse> Courses { get; set; }

        public Dictionary<string, List<AssessmentAssistant.Models.CourseOutcome>> CourseOutcomes { get; set; }
      
        public ProgramOutcomeReportModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            programid = id;
            measurementperiod = this.MeasurementPeriod();

            // Get all the elements of the report 
            ProgramOutcomes = _context.GetProgramOutcomes(programid, measurementperiod);

            Courses = _context.GetAcademicCoursesForProgram(programid, measurementperiod);
            
            CourseOutcomes = new Dictionary<string, List<Models.CourseOutcome>>();
            
            foreach (AssessmentAssistant.Models.AcademicCourse course in Courses) { 
                CourseOutcomes[course.CourseTitle] = _context.GetCourseOutcomes(course.AcademicCourseId, measurementperiod);
            }
;
            if (id == null || _context.AcademicPrograms == null)
            {
                return NotFound();
            }

            var academicprogram = await _context.AcademicPrograms.FirstOrDefaultAsync(m => m.AcademicProgramId == id);
            if (academicprogram == null)
            {
                return NotFound();
            }
            else 
            {
                AcademicProgram = academicprogram;
            }
            return Page();
        }


    }
}
