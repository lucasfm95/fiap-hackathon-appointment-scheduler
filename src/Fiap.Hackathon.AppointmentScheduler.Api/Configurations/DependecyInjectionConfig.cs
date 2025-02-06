using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Application.Services;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Configurations;

internal static class DependencyInjectionConfig
{
    internal static void RegisterRepositories(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IDoctorRepository,DoctorRepository>();
        serviceProvider.AddScoped<IPatientRepository, PatientRepository>();
        serviceProvider.AddScoped<IAppointmentSlotRepository, AppointmentSlotRepository>();
        serviceProvider.AddScoped<IAppointmentRepository, AppointmentRepository>();
    }
    
    internal static void RegisterApplicationServices(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<DoctorService>();
        serviceProvider.AddScoped<PatientService>();
        serviceProvider.AddScoped<AppointmentSlotService>();
        serviceProvider.AddScoped<AppointmentService>();
    }
}