using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.OutcomeMeasure
{
    public class IndexModel : AAPageModel
    {

        public IndexModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssessmentAssistant.Models.OutcomeMeasure> OutcomeMeasure { get;set; } = default!;

        public async Task OnGetAsync(long? id)
        {
            offeringid = id;

            if (_context.OutcomeMeasures != null)
            {
                OutcomeMeasure = await _context.OutcomeMeasures
                    .Where(o => o.CourseOfferingId == offeringid)
                    .Include(o => o.CourseOffering)
                    .ToListAsync();
            }
        }
    }
}
