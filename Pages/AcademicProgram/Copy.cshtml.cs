using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;
using System.ComponentModel.DataAnnotations;

namespace AssessmentAssistant.Pages.AcademicProgram
{
    public class CopyModel : AAPageModel
    {
        //private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public List<MeasurementPeriods> MeasurementPeriods { get; set; }

        public CopyModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public long? programid;

        [StringLength(200)]
        [Required]
        public string newmeasurementperiod;

      public AssessmentAssistant.Models.AcademicProgram AcademicProgram { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.AcademicPrograms == null)
            {
                return NotFound();
            }
            programid = id;
            var academicprogram = await _context.AcademicPrograms.FirstOrDefaultAsync(m => m.AcademicProgramId == id);
            if (academicprogram == null)
            {
                return NotFound();
            }
            else 
            {
                AcademicProgram = academicprogram;
            }
            MeasurementPeriods = _context.GetMeasurementPeriods();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            programid = Convert.ToInt64(Request.Form["programid"]);
            newmeasurementperiod = Request.Form["newmeasurementperiod"];

            _context.CopyAcademicProgram(programid, newmeasurementperiod);

            return Redirect("./Index");
        }
    }
}
