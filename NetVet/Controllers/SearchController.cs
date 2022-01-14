using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetVet.AppointmentData;
using NetVet.Models;

namespace NetVet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private IAppointmentData _appointmentData;

        public SearchController(IAppointmentData appointmentData)
        {
            _appointmentData = appointmentData;
        }

        [HttpGet]
        [Route("{search}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> Search(string searchString, DateTime? dateTime)
        {
            try
            {
                var result = await _appointmentData.Search(searchString, dateTime);

                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
                throw;
            }
        }
    }
}