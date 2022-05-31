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
    public class CreateModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; }

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // The id here is the id of the Academic program for the outcome
            if (id == null) return NotFound();

            AcademicProgram = await _context.AcademicPrograms.FirstOrDefaultAsync(m => m.AcademicProgramId == id);

            ViewData["AcademicProgramId"] = new SelectList(_context.AcademicPrograms, "AcademicProgramId", "AcademicProgramId");

            
            if (AcademicProgram == null)
            {
                return NotFound();
            }

            MeasurementPeriodList = _context.GetMeasurementPeriods();
            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.ProgramOutcome ProgramOutcome { get; set; } = default!;
        public List<SelectListItem> MeasurementPeriodList { get; set; }

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

        public string UserId()
        {
            if (User.Identity == null) return "";
            string userName = User.Identity.Name;
            if (userName != null) return userName;
            return "";
        }


    }
}
