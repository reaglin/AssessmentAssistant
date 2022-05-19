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
    public class DetailsModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public DetailsModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
