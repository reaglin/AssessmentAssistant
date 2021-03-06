using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.ProgramOutcome
{
    public class IndexModel : AAPageModel
    {
        //private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public IndexModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssessmentAssistant.Models.ProgramOutcome> ProgramOutcome { get;set; } = default!;

        public async Task OnGetAsync(long? id)
        {
            programid = id;
            if (_context.ProgramOutcomes != null)
            {
                ProgramOutcome = await _context.ProgramOutcomes
                    .Where(po => po.AcademicProgramId == programid)
                    .Include(p => p.AcademicProgram)
                    .ToListAsync();
            }
        }
    }
}
