using CQRSMediatR.Commads;
using CQRSMediatR.Quries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _mediator.Send(new GetUsersQuery());

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}