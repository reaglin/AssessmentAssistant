using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.AcademicProgram
{
    public class DetailsModel : AAPageModel
    {

        public DetailsModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; }
        public List<AssessmentAssistant.Models.AcademicCourse> AcademicCourses { get; set;}
        public List<AssessmentAssistant.Models.ProgramOutcome> ProgramOutcomes { get; set;}


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            programid = id;
            if (id == null)
            {
                return NotFound();
            }

            // Load the Academic Program - return a Not Found if program is not found
            AcademicProgram = await _context.AcademicPrograms.FirstOrDefaultAsync(m => m.AcademicProgramId == id);
            if (AcademicProgram == null)
            {
                return NotFound();
            }

            measurementperiod = AcademicProgram.MeasurementPeriod;
            UserSettingsId = _context.GetUserSettingsId(User.Identity.Name); 

            // Explicit Loading of Associated Courses
            // https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/read-related-data?view=aspnetcore-6.0&tabs=visual-studio
            AcademicCourses = new List<AssessmentAssistant.Models.AcademicCourse>();

            // Load the courses
            _context.GetAcademicCourses(programid, measurementperiod);

            if (AcademicProgram.AcademicCourses != null)
            {
                foreach (Models.AcademicCourse c in AcademicProgram.AcademicCourses)
                {
                    AcademicCourses.Add(c);
                }
            }

            // Explicit Loading of Program Outcomes
            // https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/read-related-data?view=aspnetcore-6.0&tabs=visual-studio

            // Load the outcomes for the academic program
            ProgramOutcomes = _context.GetProgramOutcomes(AcademicProgram.AcademicProgramId, AcademicProgram.MeasurementPeriod);

            //if (AcademicProgram.ProgramOutcomes != null)
            //{
            //    foreach (Models.ProgramOutcome po in AcademicProgram.ProgramOutcomes)
            //    {
            //        ProgramOutcomes.Add(po);
            //    }
            //}
            return Page();
        }
    }
}
