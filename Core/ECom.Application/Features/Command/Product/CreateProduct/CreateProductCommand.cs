using ECom.Application.Abstractions.Hubs;
using ECom.Application.Repositories.Attribute;
using ECom.Application.Repositories.Brand;
using ECom.Application.Repositories.Category;
using ECom.Application.Repositories.Product;
using ECom.Application.Repositories.ProductAttribute;
using MediatR;

namespace ECom.Application.Features.Command.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{

    readonly IProductWriteRepository _productWriteRepository;
    readonly IBrandReadRepository _brandReadRepository;
    readonly ICategoryReadRepository _categoryReadRepository;
    readonly IProductHubService _productHubService;
    readonly IAttributeReadRepository _attributeReadRepository;
    readonly IProductAttributeWriteRepository _productAttributeWriteRepository;

    public CreateProductCommandHandler(IProductWriteRepository ProductWriteRepository, IProductHubService productHubService, IBrandReadRepository brandReadRepository, ICategoryReadRepository categoryReadRepository, IAttributeReadRepository attributeReadRepository, IProductAttributeWriteRepository productAttributeWriteRepository)
    {
        _productWriteRepository = ProductWriteRepository;
        _productHubService = productHubService;
        _brandReadRepository = brandReadRepository;
        _categoryReadRepository = categoryReadRepository;
        _attributeReadRepository = attributeReadRepository;
        _productAttributeWriteRepository = productAttributeWriteRepository;
    }

    Guid NewProductId = Guid.NewGuid();

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        //var Attribute = _attributeReadRepository.GetAll().Where(s => s.Name == request.Attribute).ToList();
        var Brand = _brandReadRepository.GetAll().Where(s => s.Name == request.Brand).ToList();
        var Category = _categoryReadRepository.GetAll().Where(s => s.Name == request.Category).ToList();

        await _productWriteRepository.AddAsync(new()
        {
            Id = NewProductId,
            Name = request.Name,
            Stock = request.Stock,
            Price = request.Price,
            Description = request.Description,
            Slug = request.Slug,
            BrandId = Brand[0].Id,
            CategoryId = Category[0].Id,
        });

        /*
        await _productAttributeWriteRepository.AddAsync(new()
        {
            ProductId = NewProductId,
            AttributeId = Attribute[0].Id,
            Value = request.AttributeValue
        });
        */

        await _productWriteRepository.SaveAsync();
        //await _productAttributeWriteRepository.SaveAsync();

        await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde ürün eklenmiştir!");

        return new();
    }
}
public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    //public string Attribute { get; set; }
    //public string AttributeValue { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
}
public class CreateProductCommandResponse
{
}
