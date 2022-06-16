using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

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
        public DbSet<Semesters>? Semesters { get; set; }
        public DbSet<UserSettings>? UserSettings { get; set; }

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
        public List<MeasurementPeriods> GetMeasurementPeriods()
        {
            List<MeasurementPeriods> Measures = this.MeasurementsPeriods.ToList();
            return Measures;
        }
        public List<SelectListItem> GetMeasurementPeriodsList()
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
            //MeasurementPeriodList = new List<SelectListItem>();
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

        public List<SelectListItem> GetSemesters()
        {
            Semesters.Load();
//            if (this.Semesters == null) { return new List<Semesters>()}
            List<Semesters> semesters = this.Semesters.ToList();

            List<SelectListItem> semesterlist = new List<SelectListItem>();

            foreach (var item in semesters)
            {
                semesterlist.Add(new SelectListItem
                {
                    Value = item.Semester,
                    Text = item.Semester
                });
            }

            return semesterlist;
        }

        public string GetMeasurementPeriodForCourse(long? id)
        {
            if (id == null) return string.Empty;

            return this.AcademicCourses
                .Where(ac => ac.AcademicCourseId == id)
                .First()
                .MeasurementPeriod; 
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

        public CourseOutcome GetCourseOutcome(long? courseoutcomeid)
        {
            if (courseoutcomeid == null) return null;

            CourseOutcome outcome = this.CourseOutcomes
                .Where(s => s.CourseOutcomeId == courseoutcomeid)
                .FirstOrDefault();

            if (outcome == null) return null;
            return outcome;
        }

        public List<ProgramOutcome> GetProgramOutcomes(long? programid, string mp = "")
        {
            // All program outcomes for a program

            if (programid == null) return new List<ProgramOutcome>();

            if (mp == "") { 
                List<ProgramOutcome> outcomes = this.ProgramOutcomes
                    .Where(s => s.AcademicProgramId == programid)
                    .OrderBy(s => s.OutcomeNumber)
                    .ToList();
                return outcomes;
            }
            else
            {
                List<ProgramOutcome> outcomes = this.ProgramOutcomes
                    .Where(s => s.AcademicProgramId == programid)
                    .Where(s => s.MeasurementPeriod == mp)
                    .OrderBy(s => s.OutcomeNumber)
                    .ToList();
                return outcomes;
            }
            return new List<ProgramOutcome>();

        }
        public List<CourseOutcome> GetCourseOutcomes(long? courseid, string mp = "")
        {
            // All Course outcomes for a course

            if (courseid == null) return new List<CourseOutcome>();
            if (mp == "") { 
                List<CourseOutcome> outcomes = this.CourseOutcomes
                    .Where(s => s.AcademicCourseId == courseid)
                    .ToList();
                return outcomes;
            }
            else
            {
                List<CourseOutcome> outcomes = this.CourseOutcomes
                    .Where(s => s.AcademicCourseId == courseid)
                    .Where(s => s.MeasurementPeriod == mp)
                    .ToList();
                return outcomes;
            }

            return new List<CourseOutcome>(); ;
        }

        public List<AcademicCourse> GetAcademicCourses(long? programid, string mp = "")
        {
            // All Academic Courses for a Program

            if (programid == null) return new List<AcademicCourse>();

            if (mp == "") { 
                List<AcademicCourse> courses = this.AcademicCourses
                    .Where(s => s.AcademicProgramId == programid)
                    .ToList();
                return courses;
            }
            else
            {
                List<AcademicCourse> courses = this.AcademicCourses
                    .Where(s => s.AcademicProgramId == programid)
                    .Where(s => s.MeasurementPeriod == mp)
                    .ToList();
                return courses;

            }
            return new List<AcademicCourse>(); ;
        }

        public List<OutcomeMeasure> GetOutcomeMeasures(long? courseofferingid, int outcomenumber, string mp = "")
        {
            if (courseofferingid == null) return new List<OutcomeMeasure>();

            List<OutcomeMeasure> measures = this.OutcomeMeasures
                .Where(s => s.CourseOfferingId == courseofferingid)
                .Where(s => s.CourseOutcomeNumber == outcomenumber)
                .Where(s => s.MeasurementPeriod == mp)
                .ToList();

            return measures;
        }

        public List<OutcomeMeasure> GetOutcomeMeasures(long? courseofferingid, string mp = "")
        {
            if (courseofferingid == null) return new List<OutcomeMeasure>();

            List<OutcomeMeasure> measures = this.OutcomeMeasures
                .Where(s => s.CourseOfferingId == courseofferingid)
                .Where(s => s.MeasurementPeriod == mp)
                .ToList();

            return measures;
        }

        public string GetAcademicProgramTitle(long? AcademicProgramId)
        {
            if (AcademicProgramId == null) return string.Empty;
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

        public string GetAcademicCourseTitle(long? AcademicCourseId)
        {
            if (AcademicCourseId == null) return String.Empty;
            List<AcademicCourse> list = this.AcademicCourses
            .Where(s => s.AcademicCourseId == AcademicCourseId)
            .ToList();

            if (list.Count > 0)
            {
                return list.FirstOrDefault().CourseTitle + " " + list.FirstOrDefault().CourseDescription;
            }
            else
            {
                return String.Empty;
            }
        }

        public List<CourseOffering> GetCourseOfferings(long? CourseId, string mp = "")
        {
            List<CourseOffering> list = this.CourseOfferings
                .Where(s => s.AcademicCourseId == CourseId)
                .ToList();

            return list;
        }

        public string GetCourseOfferingTitle(long? CourseOfferingId)
        {
            List<CourseOffering> list = this.CourseOfferings
                .Where(s => s.CourseOfferingId == CourseOfferingId)
                .ToList();

            long? courseid = list.FirstOrDefault().AcademicCourseId;

            string retVal = String.Empty;
            if (courseid != null)
            {
                retVal = GetAcademicCourseTitle(courseid);
            }

            retVal += " " + list.FirstOrDefault().Semester;

            return retVal;

        }

            public IEnumerable<SelectListItem> GetTrueFalse()
        {
            return  new List<SelectListItem>() {
                new SelectListItem { Text = "True", Value = "1"},
                new SelectListItem { Text = "False", Value = "0"}};
               
        }

        public IEnumerable<AcademicCourse> GetAcademicCoursesForUser(string user)
        {
            if (this.AcademicCourses == null) { return new List<AcademicCourse>(); }

            IEnumerable<AcademicCourse> list = this.AcademicCourses
                .Where(s => s.CourseCoordinatorID == user);

            return list;
        }


        public CourseOffering GetCourseOffering(long? id)
        {
            CourseOffering offering;
            offering = this.CourseOfferings
                .Where(o => o.CourseOfferingId == id)
                .FirstOrDefault();

            if (offering == null) return null; 
            return offering;
        }

        public AcademicCourse GetAcademicCourse(long? id)
        {
            AcademicCourse course;
            course = this.AcademicCourses
                .Where(o => o.AcademicCourseId == id)
                .FirstOrDefault();

            if (course == null) return null;
            return course;
        }

        public AcademicProgram GetAcademicProgram(long? id)
        {
            AcademicProgram program;
            program = this.AcademicPrograms
                .Where(o => o.AcademicProgramId == id)
                .FirstOrDefault();

            if (program == null) return null;
            return program;
        }

        public ProgramOutcome GetProgramOutcome(long? id)
        {
            ProgramOutcome outcome;
            outcome = this.ProgramOutcomes
                .Where(o => o.ProgramOutcomeId == id)
                .FirstOrDefault();

            if (outcome == null) return null;
            return outcome;
        }
        #endregion

        #region "Helper Methods for Pages"

        public string UserId(ClaimsPrincipal User)
        {
            if (User.Identity == null) return "";
            string userName = User.Identity.Name;
            if (userName != null) return userName;
            return "";
        }

        public string GetDefaultMeasurementPeriod(string UserId)
        {
            if (this.UserSettings == null) { return ""; }
            try
            {
                string mp = this.UserSettings
                    .Where(g => g.UserId == UserId)
                    .First()
                    .MeasurementPeriod;
                return mp;
            }
            catch (Exception ex) { return ""; }
            return "";
        }
        public string GetUserSettingsId(string UserId)
        {
            if (this.UserSettings == null) { return null; }
            try
            {
                string mp = this.UserSettings
                    .Where(g => g.UserId == UserId)
                    .First()
                    .UserSettingsId
                    .ToString();
                return mp;
            }
            catch (Exception ex) { return null; }
            return null;
        }
        #endregion

        #region "Methods to Copy Program, Course, Outcomes"
        /* Each measurement period must have a full copy of all elements
           Academic Program and all dependent elements

           Courses
           Program Outcomes
           Course Outcomes
        
           Each new evaluation requires a new measurement period

        */
        public bool CopyAcademicProgram(long? programid, string newmp)
        {
            if (programid == null) { return false; }
            AddMeasurementPeriod(newmp);

            AcademicProgram AcademicProgramSource = this.GetAcademicProgram(programid);
            AcademicProgram AcademicProgramDest = new AcademicProgram();

            // This copies ALL values from one to the other;  
            var sourceValues = this.Entry(AcademicProgramSource).CurrentValues;
            this.Entry(AcademicProgramDest).CurrentValues.SetValues(sourceValues);

            // Change values for the desitnation
            AcademicProgramDest.MeasurementPeriod = newmp;
            AcademicProgramDest.AcademicProgramId = 0;
            this.AcademicPrograms.Add(AcademicProgramDest);
            this.SaveChanges();

            long? NewId = AcademicProgramDest.AcademicProgramId;
            if (NewId == null) { return false; }

            // Copy Associated Courses
            List<AcademicCourse> courses = this.GetAcademicCourses(programid);
            foreach(AcademicCourse course in courses)
            {
                CopyAcademicCourse(course.AcademicCourseId, NewId, newmp);
            }

            // Copy Associated program Outcomes
            List<ProgramOutcome> outcomes = this.GetProgramOutcomes(programid);
            foreach (ProgramOutcome outcome in outcomes)
            {
                CopyProgramOutcome(outcome.ProgramOutcomeId, NewId, newmp);
            }

            return true;  
        }

        public bool AddMeasurementPeriod(string NewMPValue)
        {
            List<MeasurementPeriods> mps = this.GetMeasurementPeriods();
            foreach (MeasurementPeriods mp in mps)
            {
                if (mp.MeasurementPeriod == NewMPValue)
                {
                    return false;
                }
            }
            MeasurementPeriods NewMeasurementPeriod = new MeasurementPeriods();
            NewMeasurementPeriod.MeasurementPeriod = NewMPValue;
            this.MeasurementsPeriods.Add(NewMeasurementPeriod);
            this.SaveChanges();

            return true;
        }

        public bool CopyAcademicCourse(long? courseid, long? programid, string newmp)
        {
            if (courseid == null) { return false; }
            if (programid == null) { return false; } 

            AcademicCourse AcademicCourseSource = this.GetAcademicCourse(courseid);
            AcademicCourse AcademicCourseDest = new AcademicCourse();

            // This copies ALL values from one to the other;  
            var sourceValues = this.Entry(AcademicCourseSource).CurrentValues;
            this.Entry(AcademicCourseDest).CurrentValues.SetValues(sourceValues);

            // Change values for the desitnation

            AcademicCourseDest.AcademicProgramId = (long)programid;
            AcademicCourseDest.MeasurementPeriod = newmp;
            AcademicCourseDest.AcademicCourseId = 0;
            this.AcademicCourses.Add(AcademicCourseDest);
            this.SaveChanges();

            long? NewId = AcademicCourseDest.AcademicCourseId;
            if (NewId == null) { return false; }

            // Copy Associated Course Outcomes
            List<CourseOutcome> outcomes = this.GetCourseOutcomes(courseid);
            foreach (CourseOutcome outcome in outcomes)
            {
                CopyCourseOutcome(outcome.AcademicCourseId, NewId, newmp);
            }

            return true;
        }

        public bool CopyProgramOutcome(long? outcomeid, long? programid, string newmp)
        {
            if (outcomeid == null) { return false; }
            if (programid == null) { return false; }

            ProgramOutcome ProgramOutcomeSource = this.GetProgramOutcome(outcomeid);
            ProgramOutcome ProgramOutcomeDest = new ProgramOutcome();

            // This copies ALL values from one to the other;  
            var sourceValues = this.Entry(ProgramOutcomeSource).CurrentValues;
            this.Entry(ProgramOutcomeDest).CurrentValues.SetValues(sourceValues);

            // Change values for the desitnation

            ProgramOutcomeDest.AcademicProgramId = (long)programid;
            ProgramOutcomeDest.MeasurementPeriod = newmp;
            ProgramOutcomeDest.ProgramOutcomeId = 0;
            this.ProgramOutcomes.Add(ProgramOutcomeDest);
            this.SaveChanges();

            return true;
        }

        public bool CopyCourseOutcome(long? outcomeid, long? courseid, string newmp)
        {
            if (outcomeid == null) { return false; }
            if (courseid == null) { return false; }

            CourseOutcome CourseOutcomeSource = this.GetCourseOutcome(outcomeid);
            CourseOutcome CourseOutcomeDest = new CourseOutcome();

            // This copies ALL values from one to the other;  
            var sourceValues = this.Entry(CourseOutcomeSource).CurrentValues;
            this.Entry(CourseOutcomeDest).CurrentValues.SetValues(sourceValues);

            // Change values for the desitnation

            CourseOutcomeDest.AcademicCourseId = (long)courseid;
            CourseOutcomeDest.MeasurementPeriod = newmp;
            CourseOutcomeDest.CourseOutcomeId = 0;
            this.CourseOutcomes.Add(CourseOutcomeDest);
            this.SaveChanges();

            return true;
        }
        #endregion

    }
}