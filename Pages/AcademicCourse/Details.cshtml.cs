using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssessmentAssistant.Pages.AcademicCourse
{
    public class DetailsModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;
        public List<AssessmentAssistant.Models.CourseOutcome> CourseOutcomes { get; set; }


        public DetailsModel(AssessmentAssistant.Data.ApplicationDbContext context)
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

            

            var academiccourse = await _context.AcademicCourses.FirstOrDefaultAsync(m => m.AcademicCourseId == id);
            if (academiccourse == null)
            {
                return NotFound();
            }
            else 
            {
                AcademicCourse = academiccourse;
            }
            CourseOutcomes = _context.GetCourseOutcomes(id);

            return Page();
        }

        public string AcademicProgramTitle()
        {
            return _context.GetAcademicProgramTitle(AcademicCourse.AcademicProgramId);
        }
    }
}
