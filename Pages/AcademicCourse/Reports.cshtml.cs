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
    public class ReportsModel : AAPageModel
    {
        
        public ReportsModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.AcademicCourse AcademicCourse { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {

            if (id == null || _context.AcademicCourses == null)
            {
                return NotFound();
            }
            courseid = id;

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
