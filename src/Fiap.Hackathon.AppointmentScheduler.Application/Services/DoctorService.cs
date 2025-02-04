using Fiap.Hackathon.AppointmentScheduler.Application.Dtos;
using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Services;

public class DoctorService(IDoctorRepository doctorRepository)
{
    public Task CreateAsync(DoctorDto doctorDto)
    {
        var doctor = new Doctor()
        {
            Name = doctorDto.Name,
            Crm = doctorDto.Crm,
            Perfil = Perfil.Doctor,
            Password = PasswordHasherHelper.Hash(doctorDto.Password),
            Specialty = doctorDto.Specialty,
            ContactInfo = doctorDto.ContactInfo
        };
        
        return doctorRepository.CreateAsync(doctor);
    }

    public async Task<IEnumerable<GetAllDoctorsDto>> GetAll()
    {
        var doctors = await doctorRepository.GetAllAsync();
        return doctors.Select(d => new GetAllDoctorsDto(d.Id, d.Crm, d.Specialty, d.ContactInfo));
    }
    
    public record GetAllDoctorsDto(long Id, string Crm, string Specialty, string ContactInfo);
}