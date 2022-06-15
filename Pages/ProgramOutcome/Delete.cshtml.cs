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
    public class DeleteModel : AAPageModel
    {
        //private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public DeleteModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AssessmentAssistant.Models.ProgramOutcome ProgramOutcome { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            Authenticate();

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
                programid = programoutcome.AcademicProgramId;
                ProgramOutcome = programoutcome;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            // id is the 
            if (id == null || _context.ProgramOutcomes == null)
            {
                return NotFound();
            }
            var programoutcome = await _context.ProgramOutcomes.FindAsync(id);


            if (programoutcome != null)
            {
                programid = programoutcome.AcademicProgramId;
                ProgramOutcome = programoutcome;
                _context.ProgramOutcomes.Remove(ProgramOutcome);
                await _context.SaveChangesAsync();
            }

            return Redirect("../AcademicProgram/Details?id=" + programid.ToString());
        }
    }
}
