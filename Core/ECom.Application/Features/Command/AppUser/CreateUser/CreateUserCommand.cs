using ECom.Application.Abstractions.Services;
using ECom.Application.DTOs.User;
using MediatR;

namespace ECom.Application.Features.Command.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        CreateUserResponse response = await _userService.CreateAsync(new()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = request.Password,
            PasswordConfirm = request.PasswordConfirm,
            Username = request.Username,
        });

        return new()
        {
            Message = response.Message,
            Succeeded = response.Succeeded,
        };
    }
}
public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}
public class CreateUserCommandResponse
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
}
