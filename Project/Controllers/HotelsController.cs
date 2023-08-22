using Application.Hotels.Commands.FilterHotels;
using Application.Hotels.Query.GetHotel;
using Application.Hotels.Query.GetIds;
using Application.Reservations.Query.GetIds;
using Application.Reservations.Query.GetReservation;
using Infrastucture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class HotelsController : ApiControllerBase
    {
        [HttpGet]
        [Route("getIds")]
        public async Task<ActionResult<IEnumerable<SelectIdName>>> GetIds()
        {
            try
            {
                return await Mediator.Send(new GetHotelIdsQuery());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("getHotel/{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(string id)
        {
            try
            {
                return await Mediator.Send(new GetHotelQuery() { Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<IEnumerable<Hotel>>> Filter(FilterHotelsCommand command)
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
