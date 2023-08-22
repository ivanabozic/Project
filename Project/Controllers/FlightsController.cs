using Application.Destinations.Command.FilterDestinations;
using Application.Flights.Commands.FilterFlights;
using Infrastucture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ApiControllerBase
    {
        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<IEnumerable<Flight>>> Filter(FilterFlightsCommand command)
        {
            try
            {
                return await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
