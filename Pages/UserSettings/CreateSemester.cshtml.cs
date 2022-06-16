using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.UserSettings
{
    public class CreateSemesterModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public List<SelectListItem> SemestersList { get; set; } 

        public CreateSemesterModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            SemestersList = _context.GetSemesters();
            return Page();
        }

        [BindProperty]
        public Semesters Semesters { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Semesters == null || Semesters == null)
            {
                return Page();
            }

            _context.Semesters.Add(Semesters);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
