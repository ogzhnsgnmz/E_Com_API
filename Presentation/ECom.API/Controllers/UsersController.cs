using ECom.Application.Abstractions.Services;
using ECom.Application.CustomAttributes;
using ECom.Application.Features.Command.AppUser.AssignRoleToUser;
using ECom.Application.Features.Command.AppUser.CreateUser;
using ECom.Application.Features.Command.AppUser.UpdatePassword;
using ECom.Application.Features.Queries.AppUser.GetAllUsers;
using ECom.Application.Features.Queries.AppUser.GetRolesToUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    readonly IMediator _mediator;
    readonly IMailService _mailService;
    public UsersController(IMediator mediator, IMailService mailService)
    {
        _mediator = mediator;
        _mailService = mailService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
    {
        CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("update-password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
    {
        UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
        return Ok(response);
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Admin")]
    public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest getAllUsersQueryRequest)
    {
        GetAllUsersQueryResponse response = await _mediator.Send(getAllUsersQueryRequest);
        return Ok(response);
    }

    [HttpGet("get-roles-to-user/{UserId}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserQueryRequest getRolesToUserQueryRequest)
    {
        GetRolesToUserQueryResponse response = await _mediator.Send(getRolesToUserQueryRequest);
        return Ok(response);
    }

    [HttpPost("assign-role-to-user")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest assignRoleToUserCommandRequest)
    {
        AssignRoleToUserCommandResponse response = await _mediator.Send(assignRoleToUserCommandRequest);
        return Ok(response);
    }
}
