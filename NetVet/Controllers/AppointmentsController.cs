using System;
using Microsoft.AspNetCore.Mvc;
using NetVet.AppointmentData;
using NetVet.Models;

namespace NetVet.Controllers
{
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private IAppointmentData _appointmentData;

        public AppointmentsController(IAppointmentData appointmentData)
        {
            _appointmentData = appointmentData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAppointments()
        {
            return Ok(_appointmentData.GetAppointments());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAppointment(Guid id)
        {
            var appointment = _appointmentData.GetAppointment(id);

            if (appointment != null)
            {
                return Ok(appointment);
            }

            return NotFound($"Appointment with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetAppointment(Appointment appointment)
        {
            _appointmentData.AddAppointment(appointment);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + appointment.Id, appointment);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteAppointment(Guid id)
        {
            var appointment = _appointmentData.GetAppointment(id);

            if (appointment != null)
            {
                _appointmentData.DeleteAppointment(appointment);
                return Ok();
            }

            return NotFound($"Appointment with Id: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditAppointment(Guid id, Appointment appointment)
        {
            var existingAppointment = _appointmentData.GetAppointment(id);

            if (existingAppointment != null)
            {
                appointment.Id = existingAppointment.Id;
                _appointmentData.EditAppointment(appointment);
            }

            return Ok(appointment);
        }
    }
}