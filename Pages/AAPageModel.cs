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

        // Place the declarations for these in the OnGet()
        public List<SelectListItem>? ApplicationUsersList { get; set; }
        public List<SelectListItem>? AcademicProgramsList { get; set; }
        public List<SelectListItem>? MeasurementPeriodList { get; set; }
        public List<SelectListItem>? SemesterList { get; set; }

        // Declarations for Lists (placed in OnGet
        //ApplicationUsersList = _context.GetApplicationUsers(); 

        //AcademicProgramsList = _context.GetAcademicPrograms();            

        //MeasurementPeriodList = _context.GetMeasurementPeriods();

        //SemesterList = _context.GetSemesters();


        public long? courseid;
        public long? programid;
        public long? offeringid;
        public string UserId()
        {
            return _context.UserId(User);
        }

        public string MeasurementPeriod()
        {
            // This is set by he user as a default setting. 
            return _context.GetDefaultMeasurementPeriod(User.Identity.Name);
        }

        //public List<SelectListItem> MeasurementPeriods()
        //{
        //    return _context.GetMeasurementPeriods();
        //}

        //public List<SelectListItem> Semesters()
        //{
        //    List<SelectListItem> list = _context.GetSemesters();
        //    return list;
        //}

        public string AcademicProgramTitle()
        {

            if (programid == null) return "Unspecified";
            return _context.GetAcademicProgramTitle(programid);
        }

        public string AcademicProgramTitle(long? id)
        {

            if (id == null) return "Unspecified";
            return _context.GetAcademicProgramTitle(id);
        }

        public string AcademicCourseTitle()
        {
            return _context.GetAcademicCourseTitle(courseid);
        }

        public string CourseOfferingTitle()
        {
            return _context.GetCourseOfferingTitle(offeringid);
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
