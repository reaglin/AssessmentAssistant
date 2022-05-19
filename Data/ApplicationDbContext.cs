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

        public IEnumerable<SelectListItem> GetMeasurementPeriods()
        {
            return GetEnumeration("MeasurementPeriod");
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


    }
}