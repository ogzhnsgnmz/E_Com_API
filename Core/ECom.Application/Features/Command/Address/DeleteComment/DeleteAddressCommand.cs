using MediatR;

namespace ECom.Application.Features.Command.Address.DeleteAddress;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
{
    public Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class DeleteAddressCommandRequest : IRequest<DeleteAddressCommandResponse>
{

}

public class DeleteAddressCommandResponse
{

}