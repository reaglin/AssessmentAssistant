using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages.CourseReview
{
    public class CreateModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public CreateModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AssessmentAssistant.Models.CourseReview CourseReview { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CourseReview == null || CourseReview == null)
            {
                return Page();
            }

            _context.CourseReview.Add(CourseReview);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
