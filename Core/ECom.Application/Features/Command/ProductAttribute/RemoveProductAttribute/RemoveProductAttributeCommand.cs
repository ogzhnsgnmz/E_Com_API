using ECom.Application.Repositories.ProductAttribute;
using MediatR;

namespace ECom.Application.Features.Command.ProductAttribute.RemoveProductAttribute;

public class RemoveProductAttributeCommandHandler : IRequestHandler<RemoveProductAttributeCommandRequest, RemoveProductAttributeCommandResponse>
{
    readonly IProductAttributeWriteRepository _productAttributeWriteRepository;

    public RemoveProductAttributeCommandHandler(IProductAttributeWriteRepository productAttributeWriteRepository)
    {
        _productAttributeWriteRepository = productAttributeWriteRepository;
    }

    public async Task<RemoveProductAttributeCommandResponse> Handle(RemoveProductAttributeCommandRequest request, CancellationToken cancellationToken)
    {
        await _productAttributeWriteRepository.RemoveAsync(request.Id);
        await _productAttributeWriteRepository.SaveAsync();
        return new();
    }
}
public class RemoveProductAttributeCommandRequest : IRequest<RemoveProductAttributeCommandResponse>
{
    public string Id { get; set; }
}
public class RemoveProductAttributeCommandResponse
{
}
