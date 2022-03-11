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
    public class IndexModel : PageModel
    {
        private readonly AssessmentAssistant.Data.ApplicationDbContext _context;

        public IndexModel(AssessmentAssistant.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<AssessmentAssistant.Models.AcademicProgram> AcademicPrograms { get; set; }
        public async Task OnGetAsync()
        {
            // Gets the entire
            AcademicPrograms = await _context.AcademicPrograms.ToListAsync();

            // If List is requested with the parameter ?v=all we can see all DonationMaterials
            // otherwise they are filtered on the user. This link Index?v=all is on the 
            // index page as an option. 
            string v = Request.Query["v"].ToString();

            if (v != "all")
            {
                //// This will filter the DonationMaterials on the current user. 
                //string uid = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                //DonationMaterials = DonationMaterials.Where(u => u.EnteredByUserId == uid).ToList();
            }
        }
    }
}
