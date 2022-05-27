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
    public class DeleteModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public DeleteModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.AcademicCourses == null)
            {
                return NotFound();
            }
            var academiccourse = await _context.AcademicCourses.FindAsync(id);

            if (academiccourse != null)
            {
                AcademicCourse = academiccourse;
                _context.AcademicCourses.Remove(AcademicCourse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
