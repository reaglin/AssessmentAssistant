// <auto-generated />
using System;
using AssessmentAssistant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssessmentAssistant.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220527155209_Required Field Changes")]
    partial class RequiredFieldChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssessmentAssistant.Models.AcademicCourse", b =>
                {
                    b.Property<long?>("AcademicCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("AcademicCourseId"), 1L, 1);

                    b.Property<long>("AcademicProgramId")
                        .HasColumnType("bigint");

                    b.Property<string>("CourseCoordinatorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnteredByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordOwnerUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicCourseId");

                    b.HasIndex("AcademicProgramId");

                    b.ToTable("AcademicCourses");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.AcademicProgram", b =>
                {
                    b.Property<long>("AcademicProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AcademicProgramId"), 1L, 1);

                    b.Property<string>("EnteredByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordOwnerUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicProgramId");

                    b.ToTable("AcademicPrograms");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AssessmentAssistant.Models.CourseOffering", b =>
                {
                    b.Property<long>("CourseOfferingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CourseOfferingId"), 1L, 1);

                    b.Property<long>("AcademicCourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("EnteredByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Number_A")
                        .HasColumnType("int");

                    b.Property<int?>("Number_B")
                        .HasColumnType("int");

                    b.Property<int?>("Number_C")
                        .HasColumnType("int");

                    b.Property<int?>("Number_D")
                        .HasColumnType("int");

                    b.Property<int?>("Number_F")
                        .HasColumnType("int");

                    b.Property<int?>("Number_W")
                        .HasColumnType("int");

                    b.Property<string>("RecordOwnerUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Semester")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseOfferingId");

                    b.HasIndex("AcademicCourseId");

                    b.ToTable("CourseOfferings");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.CourseOutcome", b =>
                {
                    b.Property<long?>("CourseOutcomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("CourseOutcomeId"), 1L, 1);

                    b.Property<long>("AcademicCourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("EnteredByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutcomeLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutcomeNumber")
                        .HasColumnType("int");

                    b.Property<string>("OutcomeStatement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProgramOutcomeNumber")
                        .HasColumnType("int");

                    b.Property<string>("RecordOwnerUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseOutcomeId");

                    b.HasIndex("AcademicCourseId");

                    b.ToTable("CourseOutcomes");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.Enumerations", b =>
                {
                    b.Property<long>("EnumerationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EnumerationId"), 1L, 1);

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnumerationId");

                    b.ToTable("Enumerations");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.MeasurementPeriods", b =>
                {
                    b.Property<string>("MeasurementPeriod")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MeasurementPeriod");

                    b.ToTable("MeasurementsPeriods");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.OutcomeMeasure", b =>
                {
                    b.Property<long>("OutcomeMeasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OutcomeMeasureId"), 1L, 1);

                    b.Property<string>("AssessmentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CourseOfferingId")
                        .HasColumnType("bigint");

                    b.Property<long>("CourseOutcomeId")
                        .HasColumnType("bigint");

                    b.Property<string>("EnteredByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementStatement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberMeasured")
                        .HasColumnType("int");

                    b.Property<int?>("NumberMeetingThreshold")
                        .HasColumnType("int");

                    b.Property<string>("RecordOwnerUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThresholdValue")
                        .HasColumnType("int");

                    b.HasKey("OutcomeMeasureId");

                    b.HasIndex("CourseOfferingId");

                    b.HasIndex("CourseOutcomeId");

                    b.ToTable("OutcomeMeasures");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.ProgramOutcome", b =>
                {
                    b.Property<long>("ProgramOutcomeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProgramOutcomeId"), 1L, 1);

                    b.Property<long>("AcademicProgramId")
                        .HasColumnType("bigint");

                    b.Property<string>("EnteredByUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementPeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutcomeNumber")
                        .HasColumnType("int");

                    b.Property<string>("OutcomeStatement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordOwnerUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramOutcomeId");

                    b.HasIndex("AcademicProgramId");

                    b.ToTable("ProgramOutcomes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AssessmentAssistant.Models.AcademicCourse", b =>
                {
                    b.HasOne("AssessmentAssistant.Models.AcademicProgram", "AcademicProgram")
                        .WithMany("AcademicCourses")
                        .HasForeignKey("AcademicProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicProgram");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.CourseOffering", b =>
                {
                    b.HasOne("AssessmentAssistant.Models.AcademicCourse", "AcademicCourse")
                        .WithMany()
                        .HasForeignKey("AcademicCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicCourse");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.CourseOutcome", b =>
                {
                    b.HasOne("AssessmentAssistant.Models.AcademicCourse", "AcademicCourse")
                        .WithMany("CourseOutcomes")
                        .HasForeignKey("AcademicCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicCourse");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.OutcomeMeasure", b =>
                {
                    b.HasOne("AssessmentAssistant.Models.CourseOffering", "CourseOffering")
                        .WithMany("OutcomeMeasures")
                        .HasForeignKey("CourseOfferingId");

                    b.HasOne("AssessmentAssistant.Models.CourseOutcome", "CourseOutcome")
                        .WithMany()
                        .HasForeignKey("CourseOutcomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseOffering");

                    b.Navigation("CourseOutcome");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.ProgramOutcome", b =>
                {
                    b.HasOne("AssessmentAssistant.Models.AcademicProgram", "AcademicProgram")
                        .WithMany("ProgramOutcomes")
                        .HasForeignKey("AcademicProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicProgram");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AssessmentAssistant.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AssessmentAssistant.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssessmentAssistant.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AssessmentAssistant.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AssessmentAssistant.Models.AcademicCourse", b =>
                {
                    b.Navigation("CourseOutcomes");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.AcademicProgram", b =>
                {
                    b.Navigation("AcademicCourses");

                    b.Navigation("ProgramOutcomes");
                });

            modelBuilder.Entity("AssessmentAssistant.Models.CourseOffering", b =>
                {
                    b.Navigation("OutcomeMeasures");
                });
#pragma warning restore 612, 618
        }
    }
}
