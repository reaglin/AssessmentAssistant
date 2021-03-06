using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.UserSettings
{
    public class DetailsModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public DetailsModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.UserSettings UserSettings { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.UserSettings == null)
            {
                return NotFound();
            }

            var UserSettings = await _context.UserSettings.FirstOrDefaultAsync(m => m.UserSettingsId == id);
            if (UserSettings == null)
            {
                return NotFound();
            }
            else 
            {
                UserSettings = UserSettings;
            }
            return Page();
        }
    }
}
