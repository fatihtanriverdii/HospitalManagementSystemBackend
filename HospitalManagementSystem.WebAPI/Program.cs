using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Infrastructure.Data;
using HospitalManagementSystem.Infrastructure.Repositories;
using HospitalManagementSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Application.Mappings;
using FluentValidation.AspNetCore;
using HospitalManagementSystem.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
 );

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder =>
        {
            builder
            .WithOrigins("http://192.168.1.111:3000", "http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
            //.SetIsOriginAllowed(origin => true);
        });
});

//Repos
builder.Services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
builder.Services.AddScoped<IDoctorRepository, EfDoctorRepository>();
builder.Services.AddScoped<IPatientRepository, EfPatientRepository>();
builder.Services.AddScoped<IAppointmentRepository, EfAppointmentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

//Services
builder.Services.AddScoped<IDepartmentService, EfDepartmentService>();
builder.Services.AddScoped<IDoctorService, EfDoctorService>();
builder.Services.AddScoped<IPatientService, EfPatientService>();
builder.Services.AddScoped<IAppointmentService, EfAppointmentService>();
builder.Services.AddScoped<IUserService, EfUserService>();

// Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Validator
builder.Services.AddControllers()
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<PatientCreateValidator>()
                );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
