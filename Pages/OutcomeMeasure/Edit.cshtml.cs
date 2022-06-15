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

namespace AssessmentAssistant.Pages.OutcomeMeasure
{
    public class EditModel : AAPageModel
    {

        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentAssistant.Models.OutcomeMeasure OutcomeMeasure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            Authenticate();

            if (id == null || _context.OutcomeMeasures == null)
            {
                return NotFound();
            }

            var outcomemeasure =  await _context.OutcomeMeasures.FirstOrDefaultAsync(m => m.OutcomeMeasureId == id);
            if (outcomemeasure == null)
            {
                return NotFound();
            }
            OutcomeMeasure = outcomemeasure;
           ViewData["CourseOfferingId"] = new SelectList(_context.CourseOfferings, "CourseOfferingId", "CourseOfferingId");
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

            _context.Attach(OutcomeMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutcomeMeasureExists(OutcomeMeasure.OutcomeMeasureId))
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

        private bool OutcomeMeasureExists(long id)
        {
          return (_context.OutcomeMeasures?.Any(e => e.OutcomeMeasureId == id)).GetValueOrDefault();
        }
    }
}
