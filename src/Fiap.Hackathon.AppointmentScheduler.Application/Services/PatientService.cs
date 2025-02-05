using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Enums;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;
using Fiap.Hackathon.AppointmentScheduler.Domain.Responses;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Services;

public class PatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public Task CreateAsync(CreatePatientRequest createPatientRequest)
    {
        var patient = new Patient()
        {
            Name = createPatientRequest.Name,
            Email = createPatientRequest.Email,
            Cpf = createPatientRequest.Cpf,
            Password = PasswordHasherHelper.Hash(createPatientRequest.Password),
            Profile = Profile.Patient
        };
        
        return _patientRepository.CreateAsync(patient);
    }
    
    public async Task<IEnumerable<GetAllPatientsResponse>> GetAll()
    {
        var patients = await _patientRepository.GetAllAsync();
        return patients.Select(p => new GetAllPatientsResponse(p.Id, p.Name, p.Email, p.Cpf));
    }
}