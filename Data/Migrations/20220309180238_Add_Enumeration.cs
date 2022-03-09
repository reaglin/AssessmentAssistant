using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssessmentAssistant.Data.Migrations
{
    public partial class Add_Enumeration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeMeasures_CourseOutcomes_CourseOutcomeID",
                table: "OutcomeMeasures");

            migrationBuilder.RenameColumn(
                name: "CourseOutcomeID",
                table: "OutcomeMeasures",
                newName: "CourseOutcomeId");

            migrationBuilder.RenameColumn(
                name: "OutcomeMeasureID",
                table: "OutcomeMeasures",
                newName: "OutcomeMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_OutcomeMeasures_CourseOutcomeID",
                table: "OutcomeMeasures",
                newName: "IX_OutcomeMeasures_CourseOutcomeId");

            migrationBuilder.RenameColumn(
                name: "CourseOutcomeID",
                table: "CourseOutcomes",
                newName: "CourseOutcomeId");

            migrationBuilder.CreateTable(
                name: "Enumerations",
                columns: table => new
                {
                    EnumerationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enumerations", x => x.EnumerationId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeMeasures_CourseOutcomes_CourseOutcomeId",
                table: "OutcomeMeasures",
                column: "CourseOutcomeId",
                principalTable: "CourseOutcomes",
                principalColumn: "CourseOutcomeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeMeasures_CourseOutcomes_CourseOutcomeId",
                table: "OutcomeMeasures");

            migrationBuilder.DropTable(
                name: "Enumerations");

            migrationBuilder.RenameColumn(
                name: "CourseOutcomeId",
                table: "OutcomeMeasures",
                newName: "CourseOutcomeID");

            migrationBuilder.RenameColumn(
                name: "OutcomeMeasureId",
                table: "OutcomeMeasures",
                newName: "OutcomeMeasureID");

            migrationBuilder.RenameIndex(
                name: "IX_OutcomeMeasures_CourseOutcomeId",
                table: "OutcomeMeasures",
                newName: "IX_OutcomeMeasures_CourseOutcomeID");

            migrationBuilder.RenameColumn(
                name: "CourseOutcomeId",
                table: "CourseOutcomes",
                newName: "CourseOutcomeID");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeMeasures_CourseOutcomes_CourseOutcomeID",
                table: "OutcomeMeasures",
                column: "CourseOutcomeID",
                principalTable: "CourseOutcomes",
                principalColumn: "CourseOutcomeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
