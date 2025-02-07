using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Configuration;

public class AppointmentConfiguration: IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.DoctorId)
            .IsRequired();
        
        builder.Property(a => a.PatientId)
            .IsRequired();
        
        builder.Property(a => a.AppointmentSlotId)
            .IsRequired();

        builder.Property(a => a.Status)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(a => a.Justification)
            .IsRequired(false)
            .HasMaxLength(500);
        
        builder
            .HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.DoctorId);
        
        builder
            .HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(a => a.PatientId);
        
        builder
            .HasOne(a => a.AppointmentSlot)
            .WithMany()
            .HasForeignKey(a => a.AppointmentSlotId);
    }
}