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

namespace AssessmentAssistant.Pages.ProgramOutcome
{
    public class EditModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
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

            var programoutcome =  await _context.ProgramOutcomes.FirstOrDefaultAsync(m => m.ProgramOutcomeId == id);
            if (programoutcome == null)
            {
                return NotFound();
            }
            ProgramOutcome = programoutcome;

            //Displays Program Title, Returns AcademicProgramId
            ViewData["AcademicProgramId"] = new SelectList(_context.AcademicPrograms, "AcademicProgramId", "ProgramTitle");
           
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

            _context.Attach(ProgramOutcome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramOutcomeExists(ProgramOutcome.ProgramOutcomeId))
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

        private bool ProgramOutcomeExists(long id)
        {
          return (_context.ProgramOutcomes?.Any(e => e.ProgramOutcomeId == id)).GetValueOrDefault();
        }
    }
}
