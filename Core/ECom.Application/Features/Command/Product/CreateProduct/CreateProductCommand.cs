using ECom.Application.Abstractions.Hubs;
using ECom.Application.Repositories.Brand;
using ECom.Application.Repositories.Category;
using ECom.Application.Repositories.Product;
using ECom.Application.Repositories.Size;
using MediatR;

namespace ECom.Application.Features.Command.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{

    readonly IProductWriteRepository _productWriteRepository;
    readonly ISizeReadRepository _sizeReadRepository;
    readonly IBrandReadRepository _brandReadRepository;
    readonly ICategoryReadRepository _categoryReadRepository;
    readonly IProductHubService _productHubService;

    public CreateProductCommandHandler(IProductWriteRepository ProductWriteRepository, IProductHubService productHubService, ISizeReadRepository sizeReadRepository, IBrandReadRepository brandReadRepository, ICategoryReadRepository categoryReadRepository)
    {
        _productWriteRepository = ProductWriteRepository;
        _productHubService = productHubService;
        _sizeReadRepository = sizeReadRepository;
        _brandReadRepository = brandReadRepository;
        _categoryReadRepository = categoryReadRepository;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var Size = _sizeReadRepository.GetAll().Where(s => s.Name == request.Size).ToList();
        var Brand = _brandReadRepository.GetAll().Where(s => s.Name == request.Brand).ToList();
        var Category = _categoryReadRepository.GetAll().Where(s => s.Name == request.Category).ToList();

        await _productWriteRepository.AddAsync(new()
        {
            Name = request.Name,
            Stock = request.Stock,
            Price = request.Price,
            SizeId = Size[0].Id,
            BrandId = Brand[0].Id,
            CategoryId = Category[0].Id,
        });

        await _productWriteRepository.SaveAsync();

        await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde ürün eklenmiştir!");

        return new();
    }
}
public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string Size { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
}
public class CreateProductCommandResponse
{
}
