using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.ProgramOutcome
{
    public class CreateModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AcademicProgramId"] = new SelectList(_context.AcademicPrograms, "AcademicProgramId", "AcademicProgramId");
            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.ProgramOutcome ProgramOutcome { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProgramOutcomes == null || ProgramOutcome == null)
            {
                return Page();
            }

            _context.ProgramOutcomes.Add(ProgramOutcome);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
