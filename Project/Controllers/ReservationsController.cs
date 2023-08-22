using Application.Recommendation.Commands;
using Application.Reservations.Command.FilterReservation;
using Application.Reservations.Query.GetIds;
using Application.Reservations.Query.GetReservation;
using Infrastucture.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class ReservationsController : ApiControllerBase
    {
        [HttpGet]
        [Route("getIds")]
        public async Task<ActionResult<IEnumerable<SelectIdName>>> GetIds()
        {
            try
            {
                return await Mediator.Send(new GetReservationIdsQuery());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("getReservation/{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(string id)
        {
            try
            {
                return await Mediator.Send(new GetReservationQuery() { Id = id});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<IEnumerable<Reservation>>> Filter(FilterReservationCommand command)
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
