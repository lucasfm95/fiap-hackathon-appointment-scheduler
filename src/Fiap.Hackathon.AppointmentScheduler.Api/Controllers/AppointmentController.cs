using Fiap.Hackathon.AppointmentScheduler.Application.Constants;
using Fiap.Hackathon.AppointmentScheduler.Application.Services;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController(AppointmentService appointmentService) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = Roles.Patient)]
    public async Task<IActionResult> CreateAppointment(CreateAppointmentRequest request)
    {
        await appointmentService.CreateAsync(request);
        return Created();
    }
    
    [HttpGet("scheduled-appointments")]
    [Authorize(Roles = Roles.Doctor)]
    public async Task<ActionResult<Appointment>> GetAllScheduledAppointmentsByDoctor()
    {
        var doctorId = User.Claims.FirstOrDefault(c => c.Type == "DoctorId");
        return Ok(await appointmentService.GetAllScheduledAppointmentsByDoctor(long.Parse(doctorId.Value)));
    }
    
    [HttpPost("set-status")]
    [Authorize(Roles = Roles.Doctor)]
    public async Task<IActionResult> SetStatusAppointment(UpdateAppointmentRequest request)
    {
        await appointmentService.UpdateStatusAsync(request.AppointmentId, request.Status,request.Justification);
        return Ok();
    }
    
    
}