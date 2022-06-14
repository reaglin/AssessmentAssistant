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

        public Dictionary<string, int> Grades = new Dictionary<string, int>()
        {
            { "A Grades", 0 },
            { "B Grades", 0 },
            { "C Grades", 0 },
            { "D Grades", 0 },
            { "F Grades", 0 },
            { "W Grades", 0 }
        };



        public async Task<IActionResult> OnGetAsync(long? id)
        {
            
            if (id == null || _context.AcademicCourses == null)
            {
                return NotFound();
            }

            courseid = id;
            measurementperiod = MeasurementPeriod();

            CourseOfferings = _context.GetCourseOfferings(courseid, measurementperiod);
            FillGrades();

            CourseOutcomes = _context.GetCourseOutcomes(courseid, measurementperiod);
            
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

         public void FillGrades()
        {
            foreach(var course in CourseOfferings)
            {
                Grades["A Grades"] += (int)course.Number_A;
                Grades["B Grades"] += (int)course.Number_B;
                Grades["C Grades"] += (int)course.Number_C;
                Grades["D Grades"] += (int)course.Number_D;
                Grades["F Grades"] += (int)course.Number_F;
                Grades["W Grades"] += (int)course.Number_W;
            }
        }
    }
}
