using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringAdmissionCommitteePersistance.Migrations
{
    public partial class removeMeritData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marits");

            migrationBuilder.CreateTable(
                name: "Merits",
                columns: table => new
                {
                    MeritId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merits", x => x.MeritId);
                    table.ForeignKey(
                        name: "FK_Merits_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Merits_Rank",
                table: "Merits",
                column: "Rank",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merits_StudentId",
                table: "Merits",
                column: "StudentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merits");

            migrationBuilder.CreateTable(
                name: "Marits",
                columns: table => new
                {
                    MaritId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marits", x => x.MaritId);
                    table.ForeignKey(
                        name: "FK_Marits_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Marits",
                columns: new[] { "MaritId", "Rank", "StudentId" },
                values: new object[] { new Guid("b626f487-5e56-49ec-b2bb-3f80c2cdee81"), 1, new Guid("5e4559e4-624d-4dae-8527-fa2219a61740") });

            migrationBuilder.CreateIndex(
                name: "IX_Marits_Rank",
                table: "Marits",
                column: "Rank",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marits_StudentId",
                table: "Marits",
                column: "StudentId",
                unique: true);
        }
    }
}
