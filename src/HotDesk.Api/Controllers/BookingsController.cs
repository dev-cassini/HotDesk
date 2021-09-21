using HotDesk.Application.Commands;
using HotDesk.Application.Commands.Bookings;
using HotDesk.Application.Dtos.Bookings;
using HotDesk.Domain.Entities;
using HotDesk.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ICreateBookingCommand _createBookingCommand;

        public BookingsController(ICreateBookingCommand createBookingCommand)
        {
            _createBookingCommand = createBookingCommand;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CreateBookingDto createBookingDto)
        {
            var commandHandler = new CommandHandler<CreateBookingDto, Booking>(_createBookingCommand);
            await commandHandler.HandleAsync(createBookingDto);

            return Ok();
        }
    }
}
