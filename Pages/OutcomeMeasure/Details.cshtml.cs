using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.OutcomeMeasure
{
    public class DetailsModel : AAPageModel
    {

        public DetailsModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.OutcomeMeasure OutcomeMeasure { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.OutcomeMeasures == null)
            {
                return NotFound();
            }

            var outcomemeasure = await _context.OutcomeMeasures.FirstOrDefaultAsync(m => m.OutcomeMeasureId == id);
            if (outcomemeasure == null)
            {
                return NotFound();
            }
            else 
            {
                OutcomeMeasure = outcomemeasure;
            }
            return Page();
        }
    }
}
