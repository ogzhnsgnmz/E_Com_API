using ECom.Application.Abstractions.Services;
using ECom.Application.DTOs.User;
using ECom.Application.Repositories.Address;
using MediatR;

namespace ECom.Application.Features.Command.AppUser.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    readonly IUserService _userService;
    readonly IAddressWriteRepository _addressWriteRepository;

    public CreateUserCommandHandler(IUserService userService, IAddressWriteRepository addressWriteRepository)
    {
        _userService = userService;
        _addressWriteRepository = addressWriteRepository;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        Guid UserId = Guid.NewGuid();

        CreateUserResponse response = await _userService.CreateAsync(new()
        {
            Id = UserId,
            Email = request.Email,
            NameSurname = request.NameSurname,
            Password = request.Password,
            PasswordConfirm = request.PasswordConfirm,
            Username = request.Username,
        });

        var Address = await _addressWriteRepository.AddAsync(new()
        {
            UserId = UserId,
            Province = request.Province,
            District = request.District,
            Neighborhood = request.Neighborhood,
            Street = request.Street,
            Number = request.Number,
            PostalCode = request.PostalCode,
            Title = request.Title
        });

        await _addressWriteRepository.SaveAsync();

        return new()
        {
            Message = response.Message,
            Succeeded = response.Succeeded,
        };
    }
}
public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public string NameSurname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }

    public string Province { get; set; }
    public string District { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string PostalCode { get; set; }
    public string Title { get; set; }
}
public class CreateUserCommandResponse
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
}
