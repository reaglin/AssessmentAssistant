using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssessmentAssistant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AcademicProgram>? AcademicPrograms { get; set; }
        public DbSet<ProgramOutcome>? ProgramOutcomes { get; set; }
        public DbSet<AcademicCourse>? AcademicCourses { get; set; }
        public DbSet<CourseOutcome>? CourseOutcomes { get; set; }
        public DbSet<CourseOffering>? CourseOfferings { get; set; }
        public DbSet<OutcomeMeasure>? OutcomeMeasures { get; set; }
        public DbSet<Enumerations>? Enumerations { get; set; }
        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<MeasurementPeriods>? MeasurementsPeriods { get;set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ProgramOutcome>()
            //    .HasOne(r => r.ProgramOutcomeId)
            //    .WithMany(u => u.AcademicProgramId);

            //builder.Entity<AcademicProgram>()
            //    .HasOne(r => r.AcademicProgramId)
            //    .WithMany(u => u.DonationRequestsFulfilled);

            base.OnModelCreating(builder);
        }

        public IEnumerable<SelectListItem> GetEnumeration(string Identifier)
        {
            if (this.Enumerations == null) { return Enumerable.Empty<SelectListItem>(); }

            IEnumerable<SelectListItem> list = this.Enumerations
                .Where(s => s.Identifier == Identifier)
                .Select(s => new SelectListItem
                {
                    Selected = false,
                    Text = s.Value,
                    Value = s.Value
                });

            return list;
        }
        #region "Methods to fill in select lists from database"

        /*
         * These methods provide acceess to the database for valuesto fill in Select Lists
         * 
         * Note the code requirements for each of the lists
         */

        public List<SelectListItem> GetMeasurementPeriods()
        {
            /*
             * This is used to fill out the select lists for MeasurementPeriods
             * 
             * Add the line
             * <select asp-for="ModelBeingUsed.MeasurementPeriod" asp-items="@Model.MeasurementPeriodList"></select>
             * 
             * Replace the ModelBeingUsed with the Model being used in the line 
             * 
             * Add variable declaration to the controller
             * public List<SelectListItem> MeasurementPeriodList { get; set; }
             * 
             * Initialize the variable in the OnGet() method of the controller
             * MeasurementPeriodList = _context.GetMeasurementPeriods();
             * 
             */

            List<MeasurementPeriods> Measures = this.MeasurementsPeriods.ToList();

            List<SelectListItem> MeasurementPeriodList = new List<SelectListItem>();
            MeasurementPeriodList = new List<SelectListItem>();
            foreach (var period in Measures)
            {
                MeasurementPeriodList.Add(new SelectListItem
                {
                    Value = period.MeasurementPeriod,
                    Text = period.MeasurementPeriod
                });
            }

            return MeasurementPeriodList;
        }

        public List<SelectListItem> GetAcademicPrograms()
        {
            /*
            * This is used to fill out the select lists for MeasurementPeriods
            * 
            * Add the line
            * <select asp-for="ModelBeingUsed.AcademicProgram" asp-items="@Model.AcademicProgramList"></select>
            * 
            * Replace the ModelBeingUsed with the Model being used in the line 
            *
            * See MethodGetMeasurementPeriods 
            */

            List<AcademicProgram> Programs = this.AcademicPrograms.ToList();
            List<SelectListItem> MeasurementPeriodList = new List<SelectListItem>();

            MeasurementPeriodList = new List<SelectListItem>();
            foreach (var program in Programs)
            {
                MeasurementPeriodList.Add(new SelectListItem
                {
                    Value = program.AcademicProgramId.ToString(),
                    Text = program.ProgramTitle
                });
            }

            return MeasurementPeriodList;
        }

        public List<SelectListItem> GetApplicationUsers()
        {
            List<ApplicationUser> ts = this.ApplicationUsers.ToList();
            List<SelectListItem> ApplicationUsersList = new List<SelectListItem>();
            foreach (var user in ts)
            {
                ApplicationUsersList.Add(new SelectListItem
                {
                    Value = user.UserName,
                    Text = user.UserName
                });
            }

            return ApplicationUsersList;
        }

        public string GetAcademicProgramTitle(int AcademicProgramId)
        {
            List<AcademicProgram> list = this.AcademicPrograms
                .Where(s => s.AcademicProgramId == AcademicProgramId)
                .ToList();

            if (list.Count > 0)
            {
                return list.FirstOrDefault().ProgramTitle; 
            }
            else
            {
                return String.Empty;
            }

        }

            public IEnumerable<SelectListItem> GetTrueFalse()
        {
            return  new List<SelectListItem>() {
                new SelectListItem { Text = "True", Value = "1"},
                new SelectListItem { Text = "False", Value = "0"}};
               
        }

        public IEnumerable<AcademicCourse> AcademicCoursesForUser(string user)
        {
            if (this.AcademicCourses == null) { return new List<AcademicCourse>(); }

            IEnumerable<AcademicCourse> list = this.AcademicCourses
                .Where(s => s.CourseCoordinatorID == user);

            return list;
        }
        #endregion

    }
}