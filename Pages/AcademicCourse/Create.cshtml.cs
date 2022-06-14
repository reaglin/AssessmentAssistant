using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.AcademicCourse
{
    public class CreateModel : AAPageModel
    {

        // Define for any drop down items in interface


        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(long? id)
        {
            if (id != null) programid = id;
            if (!Validate()) return RedirectToPage("../Index");

            ViewData["AcademicProgramId"] = new SelectList(_context.AcademicPrograms, "AcademicProgramId", "AcademicProgramId");

            // Fill in for drop down items in list (from database) 
            ApplicationUsersList = _context.GetApplicationUsers(); 

            AcademicProgramsList = _context.GetAcademicPrograms();            

            MeasurementPeriodList = _context.GetMeasurementPeriodsList();

            SemesterList = _context.GetSemesters();



            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.AcademicCourse AcademicCourse { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.AcademicCourses == null || AcademicCourse == null)
            {
                return Page();
            }


            _context.AcademicCourses.Add(AcademicCourse);
            await _context.SaveChangesAsync();

            return Redirect("../AcademicProgram/Details?id=" + AcademicCourse.AcademicProgramId.ToString());
        }

    }
}
