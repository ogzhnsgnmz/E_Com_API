using ECom.Application.Repositories.Product;
using MediatR;

namespace ECom.Application.Features.Command.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    readonly IProductWriteRepository _ProductWriteRepository;

    public CreateProductCommandHandler(IProductWriteRepository ProductWriteRepository)
    {
        _ProductWriteRepository = ProductWriteRepository;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _ProductWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Stock = request.Stock,
            Price = request.Price,
            IsOfferable = request.IsOfferable,
            IsSold = request.IsSold,
        });

        await _ProductWriteRepository.SaveAsync();

        return new();
    }
}
public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public bool IsOfferable { get; set; }
    public bool IsSold { get; set; }
}
public class CreateProductCommandResponse
{
}
