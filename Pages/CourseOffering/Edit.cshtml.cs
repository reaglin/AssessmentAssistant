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

namespace AssessmentAssistant.Pages.CourseOffering
{
    public class EditModel : AAPageModel
    {
        //private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public EditModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AssessmentAssistant.Models.CourseOffering CourseOffering { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.CourseOfferings == null)
            {
                return NotFound();
            }

            var courseoffering =  await _context.CourseOfferings.FirstOrDefaultAsync(m => m.CourseOfferingId == id);
            if (courseoffering == null)
            {
                return NotFound();
            }
            CourseOffering = courseoffering;
            courseid = CourseOffering.AcademicCourseId;
           ViewData["AcademicCourseId"] = new SelectList(_context.AcademicCourses, "AcademicCourseId", "AcademicCourseId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CourseOffering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseOfferingExists(CourseOffering.CourseOfferingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("Index?id="+courseid.ToString());
        }

        private bool CourseOfferingExists(long id)
        {
          return (_context.CourseOfferings?.Any(e => e.CourseOfferingId == id)).GetValueOrDefault();
        }
    }
}
