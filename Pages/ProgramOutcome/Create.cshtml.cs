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
    public class CreateModel : AAPageModel
    {
        //private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; }

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // The id here is the id of the Academic program for the outcome
            if (id == null) return NotFound();

            programid = id;

            AcademicProgram = await _context.AcademicPrograms.FirstOrDefaultAsync(m => m.AcademicProgramId == id);

            ViewData["AcademicProgramId"] = new SelectList(_context.AcademicPrograms, "AcademicProgramId", "AcademicProgramId");

            
            if (AcademicProgram == null)
            {
                return NotFound();
            }


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


            return Redirect("../AcademicProgram/Details?id="+programid.ToString());
        }
    }
}
