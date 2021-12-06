using HotDesk.Application.Queries.Desks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotDesk.Api.Controllers
{
    /// <summary>
    /// Api to perform operations on the desk resource.
    /// </summary>
    /// <response code="400">Validation of the request failed.</response>
    /// <response code="401">Authentication failed.</response>
    /// <response code="403">Authorisation failed.</response>
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status403Forbidden)]
    public class DesksController : ControllerBase
    {
        private readonly IDeskQuery _deskQuery;

        public DesksController(IDeskQuery deskQuery)
        {
            _deskQuery = deskQuery;
        }
    }
}
