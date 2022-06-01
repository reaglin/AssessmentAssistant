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

namespace AssessmentAssistant.Pages.CourseOutcome
{
    public class CreateModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public List<SelectListItem> ApplicationUsersList { get; set; }

        public List<SelectListItem> AcademicProgramsList { get; set; }

        public long? courseid { get; set; }

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            courseid = id;
            var academiccourse = await _context.AcademicCourses.FirstOrDefaultAsync(m => m.AcademicCourseId == id);
            if (academiccourse == null)
            {
                return NotFound();
            }


            ViewData["AcademicCourseId"] = new SelectList(_context.AcademicCourses, "AcademicCourseId", "AcademicCourseId");

            ApplicationUsersList = _context.GetApplicationUsers();

            AcademicProgramsList = _context.GetAcademicPrograms();

            

            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.CourseOutcome CourseOutcome { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CourseOutcomes == null || CourseOutcome == null)
            {
                return Page();
            }

            _context.CourseOutcomes.Add(CourseOutcome);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public string UserId()
        {
            if (User.Identity == null) return "";
            string userName = User.Identity.Name;
            if (userName != null) return userName;
            return "";
        }

        public string MeasurementPeriod()
        {
            if (courseid == null) return null;
            return _context.GetmeasurementPeriodForCourse(courseid);
        }
    }
}
