using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseReviewStandards
{
    public class DetailsModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public DetailsModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.CourseReviewStandards CourseReviewStandards { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.CourseReviewStandards == null)
            {
                return NotFound();
            }

            var coursereviewstandards = await _context.CourseReviewStandards.FirstOrDefaultAsync(m => m.CourseReviewStandardsId == id);
            if (coursereviewstandards == null)
            {
                return NotFound();
            }
            else 
            {
                CourseReviewStandards = coursereviewstandards;
            }
            return Page();
        }
    }
}
