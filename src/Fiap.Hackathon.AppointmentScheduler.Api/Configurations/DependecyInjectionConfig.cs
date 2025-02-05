using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Application.Services;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Configurations;

internal static class DependencyInjectionConfig
{
    internal static void RegisterRepositories(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddSingleton<IDoctorRepository,DoctorRepository>();
        serviceProvider.AddSingleton<IPatientRepository, PatientRepository>();
    }
    
    internal static void RegisterApplicationServices(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<DoctorService>();
        serviceProvider.AddScoped<PatientService>();
    }
}