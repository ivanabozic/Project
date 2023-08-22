using Application.Destinations.Command.FilterDestinations;
using Application.Recommendation.Commands;
using Infrastucture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{

    public class RecommendationController : ApiControllerBase
    {
        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<IEnumerable<Recommendation>>> Filter(FilterRecommendationCommand command)
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
