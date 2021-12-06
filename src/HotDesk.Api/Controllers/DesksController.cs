using HotDesk.Application.Dtos.Desks;
using HotDesk.Application.Queries.Desks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Get desks belonging to a location department.
        /// </summary>
        /// <returns>A list of desk that belong to a location department.</returns>
        /// <response code="200">Desks were retrieved successfully.</response>
        [HttpGet("location/{locationId}/department/{departmentId}")]
        [ProducesResponseType(typeof(List<DeskDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid locationId, Guid departmentId)
        {
            
            return Ok(await _deskQuery.GetAsync(locationId, departmentId));
        }
    }
}
