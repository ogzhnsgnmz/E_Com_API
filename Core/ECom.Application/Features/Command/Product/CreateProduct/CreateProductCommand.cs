using ECom.Application.Abstractions.Hubs;
using ECom.Application.Repositories.Product;
using ECom.Domain.Entities;
using ECom.Domain.Entities.Identity;
using MediatR;
using System.Drawing;

namespace ECom.Application.Features.Command.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    readonly IProductWriteRepository _ProductWriteRepository;
    readonly IProductHubService _productHubService;

    public CreateProductCommandHandler(IProductWriteRepository ProductWriteRepository, IProductHubService productHubService)
    {
        _ProductWriteRepository = ProductWriteRepository;
        _productHubService = productHubService;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        await _ProductWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Stock = request.Stock,
            Price = request.Price,
        });

        await _ProductWriteRepository.SaveAsync();

        await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde ürün eklenmiştir!");

        return new();
    }
}
public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
}
public class CreateProductCommandResponse
{
}
