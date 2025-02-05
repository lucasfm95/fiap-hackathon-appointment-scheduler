using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Enums;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;
using Fiap.Hackathon.AppointmentScheduler.Domain.Responses;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Services;

public class DoctorService(IDoctorRepository doctorRepository)
{
    public Task CreateAsync(CreateDoctorRequest createDoctorRequest)
    {
        var doctor = new Doctor()
        {
            Name = createDoctorRequest.Name,
            Crm = createDoctorRequest.Crm,
            Profile = Profile.Doctor,
            Password = PasswordHasherHelper.Hash(createDoctorRequest.Password),
            Specialty = createDoctorRequest.Specialty
        };
        
        return doctorRepository.CreateAsync(doctor);
    }

    public async Task<IEnumerable<GetAllDoctorsResponse>> GetAll()
    {
        var doctors = await doctorRepository.GetAllAsync();
        return doctors.Select(d => new GetAllDoctorsResponse(d.Id, d.Name, d.Crm, d.Specialty, d.AppointmentValue));
    }

    public async Task<IEnumerable<GetAllDoctorsResponse>> GetFiltered(string specialty, string name, string crm)
    {
        var doctors = await doctorRepository.GetFiltered(specialty, name, crm);
        return doctors.Select(d => new GetAllDoctorsResponse(d.Id, d.Name, d.Crm, d.Specialty));
    }
}