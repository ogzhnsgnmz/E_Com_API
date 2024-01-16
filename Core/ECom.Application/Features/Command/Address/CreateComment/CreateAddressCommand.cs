using ECom.Application.Repositories.Address;
using MediatR;

namespace ECom.Application.Features.Command.Address.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
{
    public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CreateAddressCommandRequest : IRequest<CreateAddressCommandResponse>
{
    public string Name { get; set; }
}

public class CreateAddressCommandResponse
{

}