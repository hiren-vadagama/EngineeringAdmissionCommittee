using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringAdmissionCommitteePersistance.Migrations
{
    public partial class addTotalseatsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalSeat",
                table: "CollegeWithCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSeat",
                table: "CollegeWithCourses");
        }
    }
}
