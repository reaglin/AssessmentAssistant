using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssessmentAssistant.Data.Migrations
{
    public partial class UserRecordTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnteredByUserName",
                table: "ProgramOutcomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecordOwnerUserName",
                table: "ProgramOutcomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnteredByUserName",
                table: "OutcomeMeasures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecordOwnerUserName",
                table: "OutcomeMeasures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnteredByUserName",
                table: "CourseOutcomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecordOwnerUserName",
                table: "CourseOutcomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnteredByUserName",
                table: "CourseOfferings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecordOwnerUserName",
                table: "CourseOfferings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnteredByUserName",
                table: "AcademicPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecordOwnerUserName",
                table: "AcademicPrograms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCoordinatorID",
                table: "AcademicCourses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EnteredByUserName",
                table: "AcademicCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecordOwnerUserName",
                table: "AcademicCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnteredByUserName",
                table: "ProgramOutcomes");

            migrationBuilder.DropColumn(
                name: "RecordOwnerUserName",
                table: "ProgramOutcomes");

            migrationBuilder.DropColumn(
                name: "EnteredByUserName",
                table: "OutcomeMeasures");

            migrationBuilder.DropColumn(
                name: "RecordOwnerUserName",
                table: "OutcomeMeasures");

            migrationBuilder.DropColumn(
                name: "EnteredByUserName",
                table: "CourseOutcomes");

            migrationBuilder.DropColumn(
                name: "RecordOwnerUserName",
                table: "CourseOutcomes");

            migrationBuilder.DropColumn(
                name: "EnteredByUserName",
                table: "CourseOfferings");

            migrationBuilder.DropColumn(
                name: "RecordOwnerUserName",
                table: "CourseOfferings");

            migrationBuilder.DropColumn(
                name: "EnteredByUserName",
                table: "AcademicPrograms");

            migrationBuilder.DropColumn(
                name: "RecordOwnerUserName",
                table: "AcademicPrograms");

            migrationBuilder.DropColumn(
                name: "EnteredByUserName",
                table: "AcademicCourses");

            migrationBuilder.DropColumn(
                name: "RecordOwnerUserName",
                table: "AcademicCourses");

            migrationBuilder.AlterColumn<string>(
                name: "CourseCoordinatorID",
                table: "AcademicCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
