﻿using HotDesk.Application.Commands.Bookings;
using HotDesk.Application.Dtos.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotDesk.Api.Controllers
{
    /// <summary>
    /// Api to perform operations on the booking resource.
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
    public class BookingsController : ControllerBase
    {
        private readonly ICreateBookingCommand _createBookingCommand;

        public BookingsController(ICreateBookingCommand createBookingCommand)
        {
            _createBookingCommand = createBookingCommand;
        }

        /// <summary>
        /// Create a new booking.
        /// </summary>
        /// <param name="createBookingDto">New booking details.</param>
        /// <returns>New booking details.</returns>
        /// <response code="204">New booking was created successfully.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Post(CreateBookingDto createBookingDto)
        {
            await _createBookingCommand.CreateAsync(createBookingDto);

            return NoContent();
        }
    }
}
