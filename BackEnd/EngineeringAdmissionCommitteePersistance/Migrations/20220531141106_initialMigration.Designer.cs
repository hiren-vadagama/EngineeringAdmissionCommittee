// <auto-generated />
using System;
using EngineeringAdmissionCommitteePersistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EngineeringAdmissionCommitteePersistance.Migrations
{
    [DbContext(typeof(EngineeringAdmissionCommitteeContext))]
    [Migration("20220531141106_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.AdminModel", b =>
                {
                    b.Property<Guid>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            AdminId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            AdminName = "Hiren"
                        });
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.AdmissionModel", b =>
                {
                    b.Property<Guid>("AdmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollegeWithCourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AdmissionId");

                    b.HasIndex("CollegeWithCourseId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Admissions");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.CollegeModel", b =>
                {
                    b.Property<Guid>("CollegeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CollegeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollegeId");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.CollegeWithCourseModel", b =>
                {
                    b.Property<Guid>("CollegeWithCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableSeat")
                        .HasColumnType("int");

                    b.Property<Guid>("CollegeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CollegeWithCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("CollegeId", "CourseId")
                        .IsUnique();

                    b.ToTable("CollegeWithCourses");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.CourseModel", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.MaritModel", b =>
                {
                    b.Property<Guid>("MaritId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaritId");

                    b.HasIndex("Rank")
                        .IsUnique();

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Marits");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.PreferenceCollegeModel", b =>
                {
                    b.Property<Guid>("PreferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollegeWithCourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PreferenceId");

                    b.HasIndex("CollegeWithCourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("PreferenceColleges");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.StudentModel", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("BoardMark")
                        .HasColumnType("real");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("GujcetMark")
                        .HasColumnType("real");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.AdmissionModel", b =>
                {
                    b.HasOne("EngineeringAdmissionCommitteePersistance.Datamodels.CollegeWithCourseModel", "CollegeWithCourse")
                        .WithMany()
                        .HasForeignKey("CollegeWithCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngineeringAdmissionCommitteePersistance.Datamodels.StudentModel", "Student")
                        .WithOne("Admission")
                        .HasForeignKey("EngineeringAdmissionCommitteePersistance.Datamodels.AdmissionModel", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CollegeWithCourse");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.CollegeWithCourseModel", b =>
                {
                    b.HasOne("EngineeringAdmissionCommitteePersistance.Datamodels.CollegeModel", "College")
                        .WithMany("CollegeWithCourses")
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngineeringAdmissionCommitteePersistance.Datamodels.CourseModel", "Course")
                        .WithMany("CollegeWithCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.MaritModel", b =>
                {
                    b.HasOne("EngineeringAdmissionCommitteePersistance.Datamodels.StudentModel", "Student")
                        .WithOne("Marit")
                        .HasForeignKey("EngineeringAdmissionCommitteePersistance.Datamodels.MaritModel", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.PreferenceCollegeModel", b =>
                {
                    b.HasOne("EngineeringAdmissionCommitteePersistance.Datamodels.CollegeWithCourseModel", "CollegeWithCourse")
                        .WithMany()
                        .HasForeignKey("CollegeWithCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EngineeringAdmissionCommitteePersistance.Datamodels.StudentModel", "Student")
                        .WithMany("PreferenceColleges")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CollegeWithCourse");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.CollegeModel", b =>
                {
                    b.Navigation("CollegeWithCourses");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.CourseModel", b =>
                {
                    b.Navigation("CollegeWithCourses");
                });

            modelBuilder.Entity("EngineeringAdmissionCommitteePersistance.Datamodels.StudentModel", b =>
                {
                    b.Navigation("Admission")
                        .IsRequired();

                    b.Navigation("Marit")
                        .IsRequired();

                    b.Navigation("PreferenceColleges");
                });
#pragma warning restore 612, 618
        }
    }
}
