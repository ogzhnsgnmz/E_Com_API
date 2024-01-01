using ECom.Application.Abstractions.Hubs;
using ECom.Application.Repositories.Brand;
using ECom.Application.Repositories.Category;
using ECom.Application.Repositories.Product;
using ECom.Application.Repositories.Size;
using ECom.Application.UnitOfWork;
using ECom.Domain.Entities;
using ECom.Domain.Entities.Identity;
using MediatR;
using System.Drawing;

namespace ECom.Application.Features.Command.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    readonly IProductWriteRepository _productWriteRepository;
    readonly ISizeWriteRepository _sizeWriteRepository;
    readonly IBrandWriteRepository _brandWriteRepository;
    readonly ICategoryWriteRepository _categoryWriteRepository;
    readonly IProductHubService _productHubService;
    readonly IUnitOfWork _unitOfWork;

    Guid SizeId = Guid.NewGuid();
    Guid BrandId = Guid.NewGuid();
    Guid CategoryId = Guid.NewGuid();

    public CreateProductCommandHandler(IProductWriteRepository ProductWriteRepository, IProductHubService productHubService, ICategoryWriteRepository categoryWriteRepository, ISizeWriteRepository sizeWriteRepository, IBrandWriteRepository brandWriteRepository, IUnitOfWork unitOfWork)
    {
        _productWriteRepository = ProductWriteRepository;
        _sizeWriteRepository = sizeWriteRepository;
        _brandWriteRepository = brandWriteRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _productHubService = productHubService;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            await _sizeWriteRepository.AddAsync(new()
            {
                Id = SizeId,
                Name = request.Size,
            });


            await _brandWriteRepository.AddAsync(new()
            {
                Id = BrandId,
                Name = request.Brand,
            });


            await _categoryWriteRepository.AddAsync(new()
            {
                Id = CategoryId,
                Name = request.Category,
            });

            await _productWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
                SizeId = SizeId,
                BrandId = BrandId,
                CategoryId = CategoryId,
            });

            await _unitOfWork.SaveAsync();
            _unitOfWork.Commit();

            await _productHubService.ProductAddedMessageAsync($"{request.Name} isminde ürün eklenmiştir!");

            return new();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
        finally
        {
            _unitOfWork.Dispose();
        }
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
