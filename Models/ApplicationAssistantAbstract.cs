using AssessmentAssistant.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentAssistant.Models
{
    public abstract class ApplicationAssistantAbstract
    {
        [Display(Name = "Measurement Period")]
        public string? MeasurementPeriod { get; set; }

        [Display(Name = "Record Entered By (email)")]
        public string? EnteredByUserName { get; set; }

        [Display(Name = "Record Owned By (email)")]
        public string? RecordOwnerUserName { get; set; }

        /*
         * The fields EnteredByUserName and RecordOwnerUserName are nornally entered into the model by directly 
         * entering the current user creating the record. This can be done by putting the following code into the View
         *  
            <div class="form-group" hidden>            
                <input asp-for="AcademicProgram.RecordOwnerUserName" class="form-control" value="@Model.UserId()" />
            </div>
            <div class="form-group" hidden>            
                <input asp-for="AcademicProgram.EnteredByUserName" class="form-control" value="@Model.UserId()" />
            </div>
         * 
         * This code relies on the following method being in the controller
         * 
         * 
         public string UserId()
        {
            if (User.Identity == null) return "";
            string userName = User.Identity.Name;
            if (userName != null) return userName;
            return "";
        }
         * 
         */


    }
}
