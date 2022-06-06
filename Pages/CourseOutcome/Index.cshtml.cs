using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseOutcome
{
    public class IndexModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public long? courseid;

        public IndexModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssessmentAssistant.Models.CourseOutcome> CourseOutcome { get;set; } = default!;

        public async Task OnGetAsync(long? id)
        {
            courseid = id;

            if (_context.CourseOutcomes != null)
            {
                if (id == null) {
                    CourseOutcome = await _context.CourseOutcomes
                    .Include(c => c.AcademicCourse).ToListAsync();
                }
                else
                {
                    CourseOutcome = await _context.CourseOutcomes
                    .Where(o => o.CourseOutcomeId == id)
                    .Include(c => c.AcademicCourse).ToListAsync();

                    ViewData["CourseId"] = courseid;
                    ViewData["CourseTitle"] = _context.GetAcademicCourseTitle(courseid);
                }
            }
        }

        public string AcademicCourseTitle()
        {
            return _context.GetAcademicCourseTitle(courseid);
        }
    }
}
