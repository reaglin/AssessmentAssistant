using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.ProgramOutcome
{
    public class DeleteModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public DeleteModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AssessmentAssistant.Models.ProgramOutcome ProgramOutcome { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.ProgramOutcomes == null)
            {
                return NotFound();
            }

            var programoutcome = await _context.ProgramOutcomes.FirstOrDefaultAsync(m => m.ProgramOutcomeId == id);

            if (programoutcome == null)
            {
                return NotFound();
            }
            else 
            {
                ProgramOutcome = programoutcome;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.ProgramOutcomes == null)
            {
                return NotFound();
            }
            var programoutcome = await _context.ProgramOutcomes.FindAsync(id);

            if (programoutcome != null)
            {
                ProgramOutcome = programoutcome;
                _context.ProgramOutcomes.Remove(ProgramOutcome);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
