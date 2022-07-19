using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseReview
{
    public class EditModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
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

            var coursereview =  await _context.CourseReview.FirstOrDefaultAsync(m => m.CourseReviewId == id);
            if (coursereview == null)
            {
                return NotFound();
            }
            CourseReview = coursereview;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CourseReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseReviewExists(CourseReview.CourseReviewId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CourseReviewExists(long id)
        {
          return (_context.CourseReview?.Any(e => e.CourseReviewId == id)).GetValueOrDefault();
        }
    }
}
