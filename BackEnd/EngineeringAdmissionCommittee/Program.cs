using EngineeringAdmissionCommitteeDomain.Repositories;
using EngineeringAdmissionCommitteePersistance;
using EngineeringAdmissionCommitteePersistance.Repositories;
using EngineeringAdmissionCommitteeServices.Services;
using EngineeringAdmissionCommitteeServices.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(setupAction =>
{
    setupAction.SerializerSettings.ContractResolver =
       new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdmissionRepository, AdmissionRepository>();
builder.Services.AddScoped<ICollegeWithCourseRepository, CollegeWithCourseRepository>();
builder.Services.AddScoped<IMeritRepository, MeritRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAdmissionService, AdmissionService>();
builder.Services.AddScoped<IMeritService, MeritService>();
builder.Services.AddScoped<ICollegeWithCourseService, CollegeWithCourseService>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddDbContext<EngineeringAdmissionCommitteeContext>(opt =>
            opt.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EngineeringAdmissionCommittee"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();