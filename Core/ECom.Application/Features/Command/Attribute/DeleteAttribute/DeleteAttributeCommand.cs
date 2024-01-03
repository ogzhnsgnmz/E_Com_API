using MediatR;

namespace ECom.Application.Features.Command.Attribute.DeleteAttribute;

public class DeleteAttributeCommandHandler : IRequestHandler<DeleteAttributeCommandRequest, DeleteAttributeCommandResponse>
{
    public Task<DeleteAttributeCommandResponse> Handle(DeleteAttributeCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class DeleteAttributeCommandRequest : IRequest<DeleteAttributeCommandResponse>
{

}

public class DeleteAttributeCommandResponse
{

}