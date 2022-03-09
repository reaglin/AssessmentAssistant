using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.AcademicProgram
{
    public class CreateModel : PageModel
    {
        public readonly AssessmentAssistant.Data.ApplicationDbContext _context;
        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // EnteredByUserId is one of the fields entered automatically. This puts 
            // in the id of the current logged in user. 
            //string id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            //DonationMaterials.EnteredByUserId = id;

            _context.AcademicPrograms.Add(AcademicProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public IEnumerable<SelectListItem> MeasurementPeriods()
        {
            return _context.GetMeasurementPeriods();
        }
    }
}
