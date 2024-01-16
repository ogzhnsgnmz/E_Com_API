using MediatR;

namespace ECom.Application.Features.Command.Address.UpdateAddress;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
{
    public Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class UpdateAddressCommandRequest : IRequest<UpdateAddressCommandResponse>
{

}

public class UpdateAddressCommandResponse
{

}