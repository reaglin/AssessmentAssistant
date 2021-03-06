using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseReview
{
    public class DeleteModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public DeleteModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AssessmentAssistant.Models.CourseReview CourseReview { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.CourseReview == null)
            {
                return NotFound();
            }

            var coursereview = await _context.CourseReview.FirstOrDefaultAsync(m => m.CourseReviewId == id);

            if (coursereview == null)
            {
                return NotFound();
            }
            else 
            {
                CourseReview = coursereview;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.CourseReview == null)
            {
                return NotFound();
            }
            var coursereview = await _context.CourseReview.FindAsync(id);

            if (coursereview != null)
            {
                CourseReview = coursereview;
                _context.CourseReview.Remove(CourseReview);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
