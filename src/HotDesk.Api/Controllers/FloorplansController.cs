using HotDesk.Application.Dtos.Floorplans;
using HotDesk.Application.Queries.Floorplans;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotDesk.Api.Controllers
{
    /// <summary>
    /// Api to perform operations on the floorplan resource.
    /// </summary>
    /// <response code="400">Validation of the request failed.</response>
    /// <response code="401">Authentication failed.</response>
    /// <response code="403">Authorisation failed.</response>
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status403Forbidden)]
    public class FloorplansController : ControllerBase
    {
        private readonly IFloorplanQuery _floorplanQuery;

        public FloorplansController(IFloorplanQuery floorplanQuery)
        {
            _floorplanQuery = floorplanQuery;
        }

        /// <summary>
        /// Get floorplan by id.
        /// </summary>
        /// <param name="floorplanId">Id of floorplan.</param>
        /// <returns>Floorplan details.</returns>
        /// <response code="200">Floorplan was retrieved successfully.</response>
        /// <response code="404">Floorplan does not exist.</response>
        [HttpGet("{floorplanId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FloorplanDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid floorplanId)
        {
            var floorplan = await _floorplanQuery.GetAsync(floorplanId);

            if (floorplan is null)
            {
                return NotFound($"Floorplan {floorplanId} does not exist.");
            }

            return Ok(floorplan);
        }
    }
}
