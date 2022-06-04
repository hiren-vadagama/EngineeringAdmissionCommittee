using EngineeringAdmissionCommitteePersistance.Datamodels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteePersistance
{
    public class EngineeringAdmissionCommitteeContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<CollegeModel> Colleges { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<MeritModel> Merits { get; set; }
        public DbSet<AdmissionModel> Admissions { get; set; }
        public DbSet<CollegeWithCourseModel> CollegeWithCourses { get; set; }
        public DbSet<PreferenceCollegeModel> PreferenceColleges { get; set; }

        public EngineeringAdmissionCommitteeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EngineeringAdmissionCommittee");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeritModel>()
            .HasIndex(marit => marit.Rank).IsUnique(true);

            modelBuilder.Entity<PreferenceCollegeModel>()
            .HasIndex(preference => new { preference.StudentId, preference.Priority }).IsUnique(true);

            modelBuilder.Entity<PreferenceCollegeModel>()
            .HasIndex(preference => new { preference.StudentId, preference.CollegeWithCourseId }).IsUnique(true);

            modelBuilder.Entity<CollegeWithCourseModel>()
            .HasIndex(collegeWithCourse => new { collegeWithCourse.CollegeId , collegeWithCourse.CourseId }).IsUnique(true);

            modelBuilder.Entity<CollegeWithCourseModel>()
            .HasOne(collegeWithCourse => collegeWithCourse.College)
            .WithMany(college => college.CollegeWithCourses)
            .HasForeignKey(collegeWithCourses => collegeWithCourses.CollegeId);

            modelBuilder.Entity<CollegeWithCourseModel>()
            .HasOne(collegeWithCours => collegeWithCours.Course)
            .WithMany(course => course.CollegeWithCourses)
            .HasForeignKey(collegeWithCourses => collegeWithCourses.CourseId );

            modelBuilder.Entity<AdminModel>().HasData(
                new AdminModel
                {
                    AdminId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    AdminName = "Hiren"
                });

            modelBuilder.Entity<StudentModel>().HasData(
                new StudentModel
                {
                    StudentId = Guid.Parse("5e4559e4-624d-4dae-8527-fa2219a61740"),
                    StudentName = "Amit",
                    Gender = "Male",
                    BoardMark = 80,
                    GujcetMark = 70,
                });
           
            modelBuilder.Entity<CollegeModel>().HasData(
                new CollegeModel
                {
                    CollegeId = Guid.Parse("8abd8dbc-0369-468b-9293-a1d598767e4e"),
                    CollegeName = "darshan institute of engineering and technology",
                },
                new CollegeModel
                {
                    CollegeId = Guid.Parse("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"),
                    CollegeName = "vvp engineering college",
                },
                new CollegeModel
                {
                    CollegeId = Guid.Parse("bf53be06-2342-41f2-b957-0e57cfbfcbca"),
                    CollegeName = "atmiya university",
                });

            modelBuilder.Entity<CourseModel>().HasData(
                new CourseModel
                {
                    CourseId = Guid.Parse("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5"),
                    CourseName = "CE",
                },
                new CourseModel
                {
                    CourseId = Guid.Parse("846bd236-1c56-49c9-81da-3acf5c38ccbb"),
                    CourseName = "ME",
                },
                new CourseModel
                {
                    CourseId = Guid.Parse("1f7f5cea-b4a4-4ad3-839b-6d1a27850186"),
                    CourseName = "EE",
                });

            modelBuilder.Entity<CollegeWithCourseModel>().HasData(
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("d41d301a-d9d7-44b8-a7d6-23d18491f811"),
                    CourseId = Guid.Parse("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5"),
                    CollegeId = Guid.Parse("8abd8dbc-0369-468b-9293-a1d598767e4e"),
                },
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("a9115fcd-854d-43c8-bffb-16fc22bee18a"),
                    CourseId = Guid.Parse("846bd236-1c56-49c9-81da-3acf5c38ccbb"),
                    CollegeId = Guid.Parse("8abd8dbc-0369-468b-9293-a1d598767e4e"),
                },
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("388afa3f-dd5c-4bb0-a637-7c6936cd4a41"),
                    CourseId = Guid.Parse("1f7f5cea-b4a4-4ad3-839b-6d1a27850186"),
                    CollegeId = Guid.Parse("8abd8dbc-0369-468b-9293-a1d598767e4e"),
                },
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("9a32dd49-a593-4f2f-a7ce-7f3db14a55c2"),
                    CourseId = Guid.Parse("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5"),
                    CollegeId = Guid.Parse("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"),
                },
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("458e5241-55fb-4c78-8b42-306c0369f86c"),
                    CourseId = Guid.Parse("846bd236-1c56-49c9-81da-3acf5c38ccbb"),
                    CollegeId = Guid.Parse("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"),
                },
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("48fef29e-e1e6-4ca5-ab5d-2a6327042d7a"),
                    CourseId = Guid.Parse("1f7f5cea-b4a4-4ad3-839b-6d1a27850186"),
                    CollegeId = Guid.Parse("84ef38fc-cb5a-4cd8-8fbc-6b79ec3450ad"),
                },
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("2e609033-65c6-4573-ad50-b488da9922a3"),
                    CourseId = Guid.Parse("75c6afbc-9eac-4d3d-98e2-97e4f0af84f5"),
                    CollegeId = Guid.Parse("bf53be06-2342-41f2-b957-0e57cfbfcbca"),
                },
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("114b297e-0064-43aa-b6ba-0895495eda93"),
                    CourseId = Guid.Parse("846bd236-1c56-49c9-81da-3acf5c38ccbb"),
                    CollegeId = Guid.Parse("bf53be06-2342-41f2-b957-0e57cfbfcbca"),
                },
                new CollegeWithCourseModel
                {
                    CollegeWithCourseId = Guid.Parse("451e9b5d-3ce1-442e-bf20-b0c289101c5b"),
                    CourseId = Guid.Parse("1f7f5cea-b4a4-4ad3-839b-6d1a27850186"),
                    CollegeId = Guid.Parse("bf53be06-2342-41f2-b957-0e57cfbfcbca"),
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}