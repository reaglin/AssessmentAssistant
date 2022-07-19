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
    public class IndexModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public IndexModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssessmentAssistant.Models.CourseStandardsReview> CourseStandardsReview { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CourseStandardsReview != null)
            {
                CourseStandardsReview = await _context.CourseStandardsReview
                .Include(c => c.CourseReviewStandard).ToListAsync();
            }
        }
    }
}
