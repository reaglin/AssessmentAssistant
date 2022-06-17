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
    public class CourseEvaluationSummary : AAPageModel
    {

        public List<AssessmentAssistant.Models.AcademicCourse> AcademicCourses { get; set; } 

        public List<AssessmentAssistant.Models.CourseOffering> CourseOfferings { get; set; }

        public CourseEvaluationSummary(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            programid = id;
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

            measurementperiod = AcademicProgram.MeasurementPeriod;
            // Gret all courses for Academic Program

            AcademicCourses = _context.GetAcademicCourses(programid, measurementperiod);

            return Page();
        }

        public List<AssessmentAssistant.Models.CourseOffering> GetCourseOfferings(long? courseid)
        {
            return _context.GetCourseOfferings(courseid);
        }
    }
}
