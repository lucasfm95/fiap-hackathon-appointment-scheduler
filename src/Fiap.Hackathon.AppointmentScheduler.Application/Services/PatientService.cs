using Fiap.Hackathon.AppointmentScheduler.Application.Dtos;
using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Services;

public class PatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public Task CreateAsync(PatientDto patientDto)
    {
        var patient = new Patient()
        {
            Name = patientDto.Name,
            Email = patientDto.Email,
            Password = PasswordHasherHelper.Hash(patientDto.Password),
            Profile = Profile.Patient
        };
        
        return _patientRepository.CreateAsync(patient);
    }
    
    public async Task<IEnumerable<GetAllPatientsDto>> GetAll()
    {
        var patients = await _patientRepository.GetAllAsync();
        return patients.Select(p => new GetAllPatientsDto(p.Id, p.Name, p.Email));
    }
    
    public record GetAllPatientsDto(long Id, string Name, string Email);
}