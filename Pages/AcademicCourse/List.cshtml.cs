using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.AcademicCourse
{
    public class ListModel : AAPageModel
    {
        public ListModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AssessmentAssistant.Models.AcademicCourse> AcademicCourse { get;set; } = default!;

        public async Task OnGetAsync(long? id)
        {
            programid = id;
            if (_context.AcademicCourses != null)
            {
                AcademicCourse = await _context.AcademicCourses
                .Include(a => a.AcademicProgram).ToListAsync();
            }
        }
    }
}
