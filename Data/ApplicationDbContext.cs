using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AssessmentAssistant.Models;

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
    }
}