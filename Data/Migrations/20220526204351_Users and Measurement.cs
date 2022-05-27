using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssessmentAssistant.Data.Migrations
{
    public partial class UsersandMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementsPeriods",
                columns: table => new
                {
                    MeasurementPeriod = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementsPeriods", x => x.MeasurementPeriod);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementsPeriods");
        }
    }
}
