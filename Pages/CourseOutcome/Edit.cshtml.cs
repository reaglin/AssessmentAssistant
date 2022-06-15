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

namespace AssessmentAssistant.Pages.CourseOutcome
{
    public class EditModel : AAPageModel
    {

        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
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

            var courseoutcome =  await _context.CourseOutcomes.FirstOrDefaultAsync(m => m.CourseOutcomeId == id);
            if (courseoutcome == null)
            {
                return NotFound();
            }
            CourseOutcome = courseoutcome;
           ViewData["AcademicCourseId"] = new SelectList(_context.AcademicCourses, "AcademicCourseId", "AcademicCourseId");
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

            _context.Attach(CourseOutcome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseOutcomeExists(CourseOutcome.CourseOutcomeId))
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

        private bool CourseOutcomeExists(long? id)
        {
          return (_context.CourseOutcomes?.Any(e => e.CourseOutcomeId == id)).GetValueOrDefault();
        }
    }
}
