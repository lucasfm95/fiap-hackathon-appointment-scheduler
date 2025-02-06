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
    [AllowAnonymous]
    public async Task<ActionResult<Appointment>> CreateAppointment(CreateAppointmentRequest request)
    {
        await appointmentService.CreateAsync(request);
        return Created();
    }
}