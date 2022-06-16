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
    public class CreateMeasurementPeriodModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public List<SelectListItem> MeasurementPeriodList { get; set; }
        public CreateMeasurementPeriodModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            MeasurementPeriodList = _context.GetMeasurementPeriodsList();

            return Page();
        }

        [BindProperty]
        public MeasurementPeriods MeasurementPeriods { get; set; } = default!;
        
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MeasurementsPeriods == null || MeasurementPeriods == null)
            {
                return Page();
            }

            _context.MeasurementsPeriods.Add(MeasurementPeriods);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
