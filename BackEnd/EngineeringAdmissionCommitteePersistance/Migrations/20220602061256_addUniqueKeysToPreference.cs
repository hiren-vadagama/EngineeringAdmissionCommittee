using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringAdmissionCommitteePersistance.Migrations
{
    public partial class addUniqueKeysToPreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreferenceColleges_StudentId",
                table: "PreferenceColleges");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceColleges_StudentId_CollegeWithCourseId",
                table: "PreferenceColleges",
                columns: new[] { "StudentId", "CollegeWithCourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceColleges_StudentId_Priority",
                table: "PreferenceColleges",
                columns: new[] { "StudentId", "Priority" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreferenceColleges_StudentId_CollegeWithCourseId",
                table: "PreferenceColleges");

            migrationBuilder.DropIndex(
                name: "IX_PreferenceColleges_StudentId_Priority",
                table: "PreferenceColleges");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceColleges_StudentId",
                table: "PreferenceColleges",
                column: "StudentId");
        }
    }
}
