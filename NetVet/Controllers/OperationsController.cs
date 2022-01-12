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
    public class OperationsController : ControllerBase
    {
        private readonly SqlAppointmentData _repository;

        public OperationsController(SqlAppointmentData repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [Route("{search}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> Search(string PetName)
        {
            try
            {
                var result = await _repository.Search(PetName);

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

        [HttpGet]
        [Route("{page}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> Pagination([FromQuery] PaginationParams paginationParams)
        {
            return await _repository.Pagination(paginationParams);
        }
    }
}