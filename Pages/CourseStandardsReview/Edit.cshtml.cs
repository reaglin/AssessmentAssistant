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

namespace AssessmentAssistant.Pages.CourseStandardsReview
{
    public class EditModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentAssistant.Models.CourseStandardsReview CourseStandardsReview { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.CourseStandardsReview == null)
            {
                return NotFound();
            }

            var coursestandardsreview =  await _context.CourseStandardsReview.FirstOrDefaultAsync(m => m.CourseStandardsReviewId == id);
            if (coursestandardsreview == null)
            {
                return NotFound();
            }
            CourseStandardsReview = coursestandardsreview;
           ViewData["CourseReviewStandardsId"] = new SelectList(_context.CourseReviewStandards, "CourseReviewStandardsId", "CourseReviewStandardsId");
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

            _context.Attach(CourseStandardsReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseStandardsReviewExists(CourseStandardsReview.CourseStandardsReviewId))
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

        private bool CourseStandardsReviewExists(long id)
        {
          return (_context.CourseStandardsReview?.Any(e => e.CourseStandardsReviewId == id)).GetValueOrDefault();
        }
    }
}
