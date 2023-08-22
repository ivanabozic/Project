using Application.Destinations.Command.FilterDestinations;
using Application.Destinations.Query.GetCountries;
using Application.Users.Commands.FilterUsers;
using Infrastucture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class DestinationController : ApiControllerBase
    {
        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<IEnumerable<Destination>>> Filter(FilterDestinationsCommand command)
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

        [HttpGet]
        [Route("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            try
            {
                return await Mediator.Send(new GetCountriesQuery());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
