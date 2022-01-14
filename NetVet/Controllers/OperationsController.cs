using System.Collections.Generic;
using System.Threading.Tasks;
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
        [Route("{page}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> Pagination([FromQuery] PaginationParams paginationParams)
        {
            return await _repository.Pagination(paginationParams);
        }
    }
}