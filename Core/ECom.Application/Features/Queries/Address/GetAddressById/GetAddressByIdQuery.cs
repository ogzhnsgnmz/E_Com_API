using ECom.Application.Abstractions.Services;
using ECom.Application.Repositories.Address;
using MediatR;

namespace ECom.Application.Features.Queries.Address.GetAddressById;

public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQueryRequest, GetAddressByIdQueryResponse>
{
    private readonly IAddressReadRepository _addressReadRepository;
    private readonly IUserService _userService;

    public GetAddressByIdQueryHandler(IAddressReadRepository addressReadRepository, IUserService userService)
    {
        _addressReadRepository = addressReadRepository;
        _userService = userService;
    }

    public async Task<GetAddressByIdQueryResponse> Handle(GetAddressByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var userId = await _userService.GetUserIdByUserNameAsync(request.UserName);

        Domain.Entities.Address address = await _addressReadRepository.GetByUserIdAsync(userId, false);
        return new()
        {
            Id = address.Id.ToString(),
            Province = address.Province,
            District = address.District,
            Neighborhood = address.Neighborhood,
            Street = address.Street,
            Number = address.Number,
            PostalCode = address.PostalCode,
            Title = address.Title,
        };
    }
}
public class GetAddressByIdQueryRequest : IRequest<GetAddressByIdQueryResponse>
{
    public string UserName { get; set; }
}
public class GetAddressByIdQueryResponse
{
    public string Id { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string PostalCode { get; set; }
    public string Title { get; set; }
}