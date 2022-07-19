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

namespace AssessmentAssistant.Pages.CourseReviewStandards
{
    public class EditModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentAssistant.Models.CourseReviewStandards CourseReviewStandards { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.CourseReviewStandards == null)
            {
                return NotFound();
            }

            var coursereviewstandards =  await _context.CourseReviewStandards.FirstOrDefaultAsync(m => m.CourseReviewStandardsId == id);
            if (coursereviewstandards == null)
            {
                return NotFound();
            }
            CourseReviewStandards = coursereviewstandards;
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

            _context.Attach(CourseReviewStandards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseReviewStandardsExists(CourseReviewStandards.CourseReviewStandardsId))
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

        private bool CourseReviewStandardsExists(long id)
        {
          return (_context.CourseReviewStandards?.Any(e => e.CourseReviewStandardsId == id)).GetValueOrDefault();
        }
    }
}
