﻿using ECom.Application.Abstractions.Services;
using ECom.Application.DTOs;
using MediatR;

namespace ECom.Application.Features.Command.AppUser.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    readonly IAuthService _authService;
    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
        return new LoginUserSuccessCommandResponse()
        {
            Token = token
        };
    }
}
public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
{
    public string ?UsernameOrEmail { get; set; }
    public string ?Password { get; set; }
}
public class LoginUserCommandResponse
{

}
public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
{
    public Token ?Token { get; set; }
}
public class LoginUserErrorCommandResponse : LoginUserCommandResponse
{
    public string ?Message { get; set; }
}
