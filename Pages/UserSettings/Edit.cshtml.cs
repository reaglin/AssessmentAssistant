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

namespace AssessmentAssistant.Pages.UserSettings
{
    public class EditModel : AAPageModel
    {
        public List<SelectListItem> MeasurementPeriodList { get; set; }
        public List<SelectListItem> AcademicProgramsList { get; set; }

        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentAssistant.Models.UserSettings UserSettings { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.UserSettings == null)
            {
                return NotFound();
            }

            var usersettings =  await _context.UserSettings.FirstOrDefaultAsync(m => m.UserSettingsId == id);
            if (usersettings == null)
            {
                return NotFound();
            }
            UserSettings = usersettings;
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

            _context.Attach(UserSettings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSettingsExists(UserSettings.UserSettingsId))
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

        private bool UserSettingsExists(long? id)
        {
          return (_context.UserSettings?.Any(e => e.UserSettingsId == id)).GetValueOrDefault();
        }
    }
}
