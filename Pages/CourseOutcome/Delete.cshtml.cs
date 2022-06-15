using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseOutcome
{
    public class DeleteModel : AAPageModel
    {

        public DeleteModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AssessmentAssistant.Models.CourseOutcome CourseOutcome { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            Authenticate();

            if (id == null || _context.CourseOutcomes == null)
            {
                return NotFound();
            }

            var courseoutcome = await _context.CourseOutcomes.FirstOrDefaultAsync(m => m.CourseOutcomeId == id);

            if (courseoutcome == null)
            {
                return NotFound();
            }
            else 
            {
                CourseOutcome = courseoutcome;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.CourseOutcomes == null)
            {
                return NotFound();
            }
            var courseoutcome = await _context.CourseOutcomes.FindAsync(id);

            if (courseoutcome != null)
            {
                CourseOutcome = courseoutcome;
                _context.CourseOutcomes.Remove(CourseOutcome);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
