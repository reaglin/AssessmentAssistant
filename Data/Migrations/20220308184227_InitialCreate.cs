using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssessmentAssistant.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserComments",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserDisplayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    AcademicProgramId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.AcademicProgramId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicCourses",
                columns: table => new
                {
                    AcademicCourseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCoordinatorID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicProgramId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurementPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicCourses", x => x.AcademicCourseId);
                    table.ForeignKey(
                        name: "FK_AcademicCourses_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "AcademicProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramOutcomes",
                columns: table => new
                {
                    ProgramOutcomeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutcomeNumber = table.Column<int>(type: "int", nullable: false),
                    OutcomeStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicProgramId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurementPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramOutcomes", x => x.ProgramOutcomeId);
                    table.ForeignKey(
                        name: "FK_ProgramOutcomes_AcademicPrograms_AcademicProgramId",
                        column: x => x.AcademicProgramId,
                        principalTable: "AcademicPrograms",
                        principalColumn: "AcademicProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseOfferings",
                columns: table => new
                {
                    CourseOfferingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semester = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicCourseId = table.Column<long>(type: "bigint", nullable: false),
                    Number_A = table.Column<int>(type: "int", nullable: true),
                    Number_B = table.Column<int>(type: "int", nullable: true),
                    Number_C = table.Column<int>(type: "int", nullable: true),
                    Number_D = table.Column<int>(type: "int", nullable: true),
                    Number_F = table.Column<int>(type: "int", nullable: true),
                    Number_W = table.Column<int>(type: "int", nullable: true),
                    MeasurementPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferings", x => x.CourseOfferingId);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_AcademicCourses_AcademicCourseId",
                        column: x => x.AcademicCourseId,
                        principalTable: "AcademicCourses",
                        principalColumn: "AcademicCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseOutcomes",
                columns: table => new
                {
                    CourseOutcomeID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutcomeNumber = table.Column<int>(type: "int", nullable: false),
                    OutcomeStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramOutcomeNumber = table.Column<int>(type: "int", nullable: true),
                    OutcomeLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicCourseId = table.Column<long>(type: "bigint", nullable: true),
                    MeasurementPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOutcomes", x => x.CourseOutcomeID);
                    table.ForeignKey(
                        name: "FK_CourseOutcomes_AcademicCourses_AcademicCourseId",
                        column: x => x.AcademicCourseId,
                        principalTable: "AcademicCourses",
                        principalColumn: "AcademicCourseId");
                });

            migrationBuilder.CreateTable(
                name: "OutcomeMeasures",
                columns: table => new
                {
                    OutcomeMeasureID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseOutcomeID = table.Column<long>(type: "bigint", nullable: false),
                    AssessmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThresholdValue = table.Column<int>(type: "int", nullable: true),
                    NumberMeasured = table.Column<int>(type: "int", nullable: true),
                    NumberMeetingThreshold = table.Column<int>(type: "int", nullable: true),
                    CourseOfferingId = table.Column<long>(type: "bigint", nullable: true),
                    MeasurementPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeMeasures", x => x.OutcomeMeasureID);
                    table.ForeignKey(
                        name: "FK_OutcomeMeasures_CourseOfferings_CourseOfferingId",
                        column: x => x.CourseOfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "CourseOfferingId");
                    table.ForeignKey(
                        name: "FK_OutcomeMeasures_CourseOutcomes_CourseOutcomeID",
                        column: x => x.CourseOutcomeID,
                        principalTable: "CourseOutcomes",
                        principalColumn: "CourseOutcomeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicCourses_AcademicProgramId",
                table: "AcademicCourses",
                column: "AcademicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_AcademicCourseId",
                table: "CourseOfferings",
                column: "AcademicCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOutcomes_AcademicCourseId",
                table: "CourseOutcomes",
                column: "AcademicCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeMeasures_CourseOfferingId",
                table: "OutcomeMeasures",
                column: "CourseOfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeMeasures_CourseOutcomeID",
                table: "OutcomeMeasures",
                column: "CourseOutcomeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramOutcomes_AcademicProgramId",
                table: "ProgramOutcomes",
                column: "AcademicProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutcomeMeasures");

            migrationBuilder.DropTable(
                name: "ProgramOutcomes");

            migrationBuilder.DropTable(
                name: "CourseOfferings");

            migrationBuilder.DropTable(
                name: "CourseOutcomes");

            migrationBuilder.DropTable(
                name: "AcademicCourses");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.DropColumn(
                name: "UserComments",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserDisplayName",
                table: "AspNetUsers");
        }
    }
}
