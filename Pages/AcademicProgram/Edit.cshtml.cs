#nullable disable
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

namespace AssessmentAssistant.Pages.AcademicProgram
{
    public class EditModel : PageModel
    {
        public readonly AssessmentAssistant.Data.ApplicationDbContext _context;
        public List<SelectListItem> MeasurementPeriodList { get; set; }
        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AcademicProgram = await _context.AcademicPrograms.FirstOrDefaultAsync(m => m.AcademicProgramId == id);

            MeasurementPeriodList = _context.GetMeasurementPeriodsList();

            if (AcademicProgram == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Puts the current logged in user in the EnteredByUserId when editing
            // the DonationMaterials. 
            // #todo? Only allow user to edit their own materials (or admin)
            //string id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            //DonationMaterials.EnteredByUserId = id;
            
            _context.Attach(AcademicProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicProgramExists((int)AcademicProgram.AcademicProgramId))
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

        private bool AcademicProgramExists(int id)
        {
            return _context.AcademicPrograms.Any(e => e.AcademicProgramId == id);
        }
        public IEnumerable<SelectListItem> MeasurementPeriods()
        {
            return _context.GetMeasurementPeriodsList();
        }
    }
}
