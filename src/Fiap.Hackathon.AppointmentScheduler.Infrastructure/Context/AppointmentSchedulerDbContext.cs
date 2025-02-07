using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;

public class AppointmentSchedulerDbContext(DbContextOptions<AppointmentSchedulerDbContext> options) : DbContext(options)
{
    static AppointmentSchedulerDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<AppointmentSlot> AppointmentSlots { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorConfiguration).Assembly);
    }
}