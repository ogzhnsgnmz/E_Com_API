using ECom.Application.Features.Command.AppUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    readonly IMediator _mediator;
    public UsersController(IMediator mediator = null)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
    {
        CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
        return Ok(response);
    }
}
