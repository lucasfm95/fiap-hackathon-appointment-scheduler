using Fiap.Hackathon.AppointmentScheduler.Api;
using Fiap.Hackathon.AppointmentScheduler.Application.Options;
using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Application.Services;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtTokenOptions>(
    builder.Configuration.GetSection("JwtTokenOptions"));

builder.ConfigureAuth();

builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddSingleton<IDoctorRepository,DoctorRepository>();
builder.Services.AddSingleton<IPatientRepository, PatientRepository>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();