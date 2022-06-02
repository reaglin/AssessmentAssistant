using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssessmentAssistant.Data;
using AssessmentAssistant.Models;

namespace AssessmentAssistant.Pages
{
    public abstract class AAPageModel : PageModel
    {
        public AssessmentAssistant.Data.ApplicationDbContext _context;

        public string UserId()
        {
            return _context.UserId(User);
        }

        public string MeasurementPeriod()
        {
            return _context.GetDefaultMeasurementPeriod(User.Identity.Name);
        }

        public bool Validate()
        {
            // This will validate, can use in OnGet method
            // to see if user is valid and measurement period is set

            // redirect to page to login or set measurement period

            // Need to create the redirect pages for these.

            if (UserId() == "")  RedirectToPage("../Index");


            if (MeasurementPeriod() == "") RedirectToPage("../Index");

            return true ;
        }

    }
}
