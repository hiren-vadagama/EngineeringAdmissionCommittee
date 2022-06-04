using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringAdmissionCommitteePersistance.Migrations
{
    public partial class addCollegeWithCoureData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Colleges",
                columns: new[] { "CollegeId", "CollegeName" },
                values: new object[,]
                {
                    { new Guid("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"), "vvp engineering college" },
                    { new Guid("8abd8dbc-0369-468b-9293-a1d598767e4e"), "darshan institute of engineering and technology" },
                    { new Guid("bf53be06-2342-41f2-b957-0e57cfbfcbca"), "atmiya university" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName" },
                values: new object[,]
                {
                    { new Guid("1f7f5cea-b4a4-4ad3-839b-6d1a27850186"), "EE" },
                    { new Guid("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5"), "CE" },
                    { new Guid("846bd236-1c56-49c9-81da-3acf5c38ccbb"), "ME" }
                });

            migrationBuilder.InsertData(
                table: "CollegeWithCourses",
                columns: new[] { "CollegeWithCourseId", "AvailableSeat", "CollegeId", "CourseId" },
                values: new object[,]
                {
                    { new Guid("114b297e-0064-43aa-b6ba-0895495eda93"), 0, new Guid("bf53be06-2342-41f2-b957-0e57cfbfcbca"), new Guid("846bd236-1c56-49c9-81da-3acf5c38ccbb") },
                    { new Guid("2e609033-65c6-4573-ad50-b488da9922a3"), 0, new Guid("bf53be06-2342-41f2-b957-0e57cfbfcbca"), new Guid("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5") },
                    { new Guid("388afa3f-dd5c-4bb0-a637-7c6936cd4a41"), 0, new Guid("8abd8dbc-0369-468b-9293-a1d598767e4e"), new Guid("1f7f5cea-b4a4-4ad3-839b-6d1a27850186") },
                    { new Guid("451e9b5d-3ce1-442e-bf20-b0c289101c5b"), 0, new Guid("bf53be06-2342-41f2-b957-0e57cfbfcbca"), new Guid("1f7f5cea-b4a4-4ad3-839b-6d1a27850186") },
                    { new Guid("458e5241-55fb-4c78-8b42-306c0369f86c"), 0, new Guid("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"), new Guid("846bd236-1c56-49c9-81da-3acf5c38ccbb") },
                    { new Guid("48fef29e-e1e6-4ca5-ab5d-2a6327042d7a"), 0, new Guid("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"), new Guid("1f7f5cea-b4a4-4ad3-839b-6d1a27850186") },
                    { new Guid("9a32dd49-a593-4f2f-a7ce-7f3db14a55c2"), 0, new Guid("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"), new Guid("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5") },
                    { new Guid("a9115fcd-854d-43c8-bffb-16fc22bee18a"), 0, new Guid("8abd8dbc-0369-468b-9293-a1d598767e4e"), new Guid("846bd236-1c56-49c9-81da-3acf5c38ccbb") },
                    { new Guid("d41d301a-d9d7-44b8-a7d6-23d18491f811"), 0, new Guid("8abd8dbc-0369-468b-9293-a1d598767e4e"), new Guid("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("114b297e-0064-43aa-b6ba-0895495eda93"));

            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("2e609033-65c6-4573-ad50-b488da9922a3"));

            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("388afa3f-dd5c-4bb0-a637-7c6936cd4a41"));

            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("451e9b5d-3ce1-442e-bf20-b0c289101c5b"));

            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("458e5241-55fb-4c78-8b42-306c0369f86c"));

            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("48fef29e-e1e6-4ca5-ab5d-2a6327042d7a"));

            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("9a32dd49-a593-4f2f-a7ce-7f3db14a55c2"));

            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("a9115fcd-854d-43c8-bffb-16fc22bee18a"));

            migrationBuilder.DeleteData(
                table: "CollegeWithCourses",
                keyColumn: "CollegeWithCourseId",
                keyValue: new Guid("d41d301a-d9d7-44b8-a7d6-23d18491f811"));

            migrationBuilder.DeleteData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: new Guid("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"));

            migrationBuilder.DeleteData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: new Guid("8abd8dbc-0369-468b-9293-a1d598767e4e"));

            migrationBuilder.DeleteData(
                table: "Colleges",
                keyColumn: "CollegeId",
                keyValue: new Guid("bf53be06-2342-41f2-b957-0e57cfbfcbca"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("1f7f5cea-b4a4-4ad3-839b-6d1a27850186"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: new Guid("846bd236-1c56-49c9-81da-3acf5c38ccbb"));
        }
    }
}
