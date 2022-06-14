using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseOffering
{
    public class CreateModel : AAPageModel
    {

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long? id)
        {

            courseid = id;

            SemesterList = _context.GetSemesters();

            //ViewData["AcademicCourseId"] = new SelectList(_context.AcademicCourses, "AcademicCourseId", "AcademicCourseId");
            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.CourseOffering CourseOffering { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CourseOfferings == null || CourseOffering == null)
            {
                return Page();
            }

            _context.CourseOfferings.Add(CourseOffering);
            await _context.SaveChangesAsync();

            return Redirect("../AcademicCourse/Details?id="+CourseOffering.AcademicCourseId.ToString());
        }
    }
}
