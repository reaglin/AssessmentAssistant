using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using AssessmentAssistant.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AssessmentAssistant.Models.AcademicCourse> courses { get; set; }

        public IEnumerable<AssessmentAssistant.Models.AcademicProgram> programs { get; set; }

        public void OnGet()
        {
            // Displayed here (upon login) - will be any programs or course that the user
            // is responsible for. 
            if (User.Identity == null) { return; }
            if (!User.Identity.IsAuthenticated) { return; }

            courses = _context.AcademicCourses
                .Where(c => c.CourseCoordinatorID == User.Identity.Name)
                .ToList();

            programs = _context.AcademicPrograms
                .Where(c => c.RecordOwnerUserName == User.Identity.Name)
                .ToList();

        }

    }
}