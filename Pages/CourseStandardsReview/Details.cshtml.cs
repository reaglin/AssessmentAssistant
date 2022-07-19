using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseStandardsReview
{
    public class DetailsModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public DetailsModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AssessmentAssistant.Models.CourseStandardsReview CourseStandardsReview { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.CourseStandardsReview == null)
            {
                return NotFound();
            }

            var coursestandardsreview = await _context.CourseStandardsReview.FirstOrDefaultAsync(m => m.CourseStandardsReviewId == id);
            if (coursestandardsreview == null)
            {
                return NotFound();
            }
            else 
            {
                CourseStandardsReview = coursestandardsreview;
            }
            return Page();
        }
    }
}
