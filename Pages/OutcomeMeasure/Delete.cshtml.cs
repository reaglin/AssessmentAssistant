using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.OutcomeMeasure
{
    public class DeleteModel : AAPageModel
    {

        public DeleteModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AssessmentAssistant.Models.OutcomeMeasure OutcomeMeasure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.OutcomeMeasures == null)
            {
                return NotFound();
            }

            var outcomemeasure = await _context.OutcomeMeasures.FirstOrDefaultAsync(m => m.OutcomeMeasureId == id);

            if (outcomemeasure == null)
            {
                return NotFound();
            }
            else 
            {
                OutcomeMeasure = outcomemeasure;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.OutcomeMeasures == null)
            {
                return NotFound();
            }
            var outcomemeasure = await _context.OutcomeMeasures.FindAsync(id);

            if (outcomemeasure != null)
            {
                OutcomeMeasure = outcomemeasure;
                _context.OutcomeMeasures.Remove(OutcomeMeasure);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
