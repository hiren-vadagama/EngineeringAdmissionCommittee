using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringAdmissionCommitteePersistance.Migrations
{
    public partial class addStudentData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "BoardMark", "Gender", "GujcetMark", "StudentName" },
                values: new object[] { new Guid("5e4559e4-624d-4dae-8527-fa2219a61740"), 80f, "Male", 70f, "Amit" });

            migrationBuilder.InsertData(
                table: "Marits",
                columns: new[] { "MaritId", "Rank", "StudentId" },
                values: new object[] { new Guid("b626f487-5e56-49ec-b2bb-3f80c2cdee81"), 1, new Guid("5e4559e4-624d-4dae-8527-fa2219a61740") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Marits",
                keyColumn: "MaritId",
                keyValue: new Guid("b626f487-5e56-49ec-b2bb-3f80c2cdee81"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("5e4559e4-624d-4dae-8527-fa2219a61740"));
        }
    }
}
