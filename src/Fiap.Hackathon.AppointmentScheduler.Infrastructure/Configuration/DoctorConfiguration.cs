using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Configuration;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(doctor => doctor.Id);
        builder.Property(k => k.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(p => p.Crm)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(p => p.Specialty)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Password)
            .IsRequired()
            .IsUnicode();
        builder.Property(p => p.Profile)
            .IsRequired()
            .HasColumnType("smallint");
        builder.HasIndex(p => p.Crm)
            .IsUnique();
        builder.Property(p => p.AppointmentValue)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
    }
}