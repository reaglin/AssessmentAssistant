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
    public class CreateModel : AAPageModel
    {
        public List<SelectListItem> ApplicationUsersList { get; set; }

        public List<SelectListItem> AcademicProgramsList { get; set; }

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            Authenticate();

            courseid = id;
            var academiccourse = await _context.AcademicCourses.FirstOrDefaultAsync(m => m.AcademicCourseId == id);
            if (academiccourse == null)
            {
                return NotFound();
            }

            ViewData["AcademicCourseId"] = new SelectList(_context.AcademicCourses, "AcademicCourseId", "AcademicCourseId");
            ViewData["CourseTitle"] = _context.GetAcademicCourseTitle(id);

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

            return Redirect("Index?id=" + CourseOutcome.AcademicCourseId);
        }

        public List<AssessmentAssistant.Models.ProgramOutcome> ProgramOutcomes()
        {
            return _context.GetProgramOutcomes(programid);
        }
    }
}
