using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseOffering
{
    public class IndexModel : AAPageModel
    {

        public IndexModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssessmentAssistant.Models.CourseOffering> CourseOffering { get;set; } = default!;

        public async Task OnGetAsync(long? id)
        {
            courseid = id;

            if (_context.CourseOfferings != null)
            {
                CourseOffering = await _context.CourseOfferings
                    .Where(c => c.AcademicCourseId == id)
                    .Include(c => c.AcademicCourse).ToListAsync();
            }
        }
    }
}
