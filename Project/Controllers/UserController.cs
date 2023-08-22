using Application.Users.Commands.FilterUsers;
using Application.Users.Query;
using Infrastucture.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class UserController : ApiControllerBase
    {
        //[ApiExplorerSettings(GroupName = "users")]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<User>>> Get([FromQuery] GetUsersQuery query)
        {
            try
            {
                return await Mediator.Send(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("filter")]
        public async Task<ActionResult<IEnumerable<User>>> Filter(FilterUsersCommand command)
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
