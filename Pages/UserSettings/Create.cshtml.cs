using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.UserSettings
{
    public class CreateModel : AAPageModel
    {

        public List<SelectListItem> MeasurementPeriodList { get; set; }

        public List<SelectListItem> AcademicProgramsList { get; set; }

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            MeasurementPeriodList = _context.GetMeasurementPeriodsList();

            AcademicProgramsList = _context.GetAcademicPrograms(); 

            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.UserSettings UserSettings { get; set; } = default!;

       

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UserSettings == null || UserSettings == null)
            {
                return Page();
            }

            _context.UserSettings.Add(UserSettings);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
