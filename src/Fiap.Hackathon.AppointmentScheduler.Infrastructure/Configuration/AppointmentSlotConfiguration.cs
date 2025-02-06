using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Configuration;

public class AppointmentSlotConfiguration : IEntityTypeConfiguration<AppointmentSlot>
{
    public void Configure(EntityTypeBuilder<AppointmentSlot> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.DoctorId)
            .IsRequired();
        
        builder.Property(a => a.AvailableDate)
            .IsRequired();
        
        builder.Property(a => a.AvailableTime)
            .IsRequired();
        
       builder
            .HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.DoctorId);
    }
}