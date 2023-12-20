using ECom.Application.Features.Command.AppUser.FacebookLogin;
using ECom.Application.Features.Command.AppUser.GoogleLogin;
using ECom.Application.Features.Command.AppUser.LoginUser;
using ECom.Application.Features.Command.AppUser.PasswordReset;
using ECom.Application.Features.Command.AppUser.RefreshTokenLogin;
using ECom.Application.Features.Command.AppUser.VerfyResetToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(AuthenticationSchemes = "")]
public class AuthController : ControllerBase
{
    readonly IMediator _mediator;
    public AuthController(IMediator mediator = null)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
    {
        LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
    {
        RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
        return Ok(response);
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
    {
        GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
        return Ok(response);
    }

    [HttpPost("facebook-login")]
    public async Task<IActionResult> FacebookLogin(FacebookLoginCommandRequest facebookLoginCommandRequest)
    {
        FacebookLoginCommandResponse response = await _mediator.Send(facebookLoginCommandRequest);
        return Ok(response);
    }

    [HttpPost("password-reset")]
    public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommandRequest passwordResetCommandRequest)
    {
        PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
        return Ok(response);
    }

    [HttpPost("verify-reset-token")]
    public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest verifyResetTokenCommandRequest)
    {
        VerifyResetTokenCommandResponse response = await _mediator.Send(verifyResetTokenCommandRequest);
        return Ok(response);
    }
}
