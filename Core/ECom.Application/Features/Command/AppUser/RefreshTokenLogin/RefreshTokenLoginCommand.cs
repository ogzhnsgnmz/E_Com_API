using ECom.Application.Abstractions.Services;
using ECom.Application.DTOs;
using MediatR;

namespace ECom.Application.Features.Command.AppUser.RefreshTokenLogin;

public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
{
    readonly IAuthService _authService;
    public RefreshTokenLoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
    {
        Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
        return new()
        {
            Token = token
        };
    }
}
public class RefreshTokenLoginCommandRequest : IRequest<RefreshTokenLoginCommandResponse>
{
    public string RefreshToken { get; set; }
}
public class RefreshTokenLoginCommandResponse
{
    public Token Token { get; set; }
}
