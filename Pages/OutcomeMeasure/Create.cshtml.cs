using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.OutcomeMeasure
{
    public class CreateModel : AAPageModel
    {
        public AssessmentAssistant.Models.AcademicCourse AcademicCourse { get; set; }

        public AssessmentAssistant.Models.CourseOffering CourseOffering { get; set; }

        public List<AssessmentAssistant.Models.CourseOutcome> CourseOutcomes { get; set; } 

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long? id)
        {
            offeringid = id;

            AssessmentAssistant.Models.CourseOffering offering = _context.GetCourseOffering(offeringid);

            if (offering == null)
            {
                return NotFound("Associated Course Offering Not Found");
            }

            courseid = offering.AcademicCourseId;
            AssessmentAssistant.Models.AcademicCourse course = _context.GetAcademicCourse(courseid);

            CourseOutcomes = _context.GetCourseOutcomes(courseid);
            

            if (course == null)

            ViewData["CourseOfferingId"] = new SelectList(_context.CourseOfferings, "CourseOfferingId", "CourseOfferingId");
            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.OutcomeMeasure OutcomeMeasure { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.OutcomeMeasures == null || OutcomeMeasure == null)
            {
                return Page();
            }

            _context.OutcomeMeasures.Add(OutcomeMeasure);
            await _context.SaveChangesAsync();

            return Redirect("./Index?id=" + OutcomeMeasure.CourseOfferingId.ToString());
        }
    }
}
