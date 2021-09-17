using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotDesk.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status401Unauthorized)]
    public class BookingsController : ControllerBase
    {
        [HttpGet("{bookingId}")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid bookingId)
        {
            return Ok();
        }
    }
}
