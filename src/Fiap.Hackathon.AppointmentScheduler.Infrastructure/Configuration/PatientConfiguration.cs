using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Configuration;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(doctor => doctor.Id);
        builder.Property(k => k.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(k => k.Email)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(200);
        builder.Property(p => p.Cpf)
            .IsRequired()
            .HasMaxLength(11);
        builder.Property(p => p.Profile)
            .IsRequired()
            .HasColumnType("smallint");
        builder.Property(p => p.Password)
            .IsRequired()
            .IsUnicode();
        builder.HasIndex(e => e.Cpf)
            .IsUnique();
    }
}