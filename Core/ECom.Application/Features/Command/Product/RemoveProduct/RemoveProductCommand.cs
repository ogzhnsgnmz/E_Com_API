using ECom.Application.Repositories.Product;
using MediatR;

namespace ECom.Application.Features.Command.Product.RemoveProduct;

public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
{
    readonly IProductWriteRepository _ProductWriteRepository;
    public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _ProductWriteRepository.RemoveAsync(request.Id);
        await _ProductWriteRepository.SaveAsync();
        return new();
    }
}
public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
{
    public string Id { get; set; }
}
public class RemoveProductCommandResponse
{
}
