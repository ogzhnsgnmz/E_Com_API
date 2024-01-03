using ECom.Application.Repositories.Category;
using ECom.Application.Repositories.Product;
using ECom.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    readonly IProductReadRepository _productReadRepository;
    readonly ICategoryReadRepository _categoryReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetAllProductQueryHandler(IProductReadRepository ProductReadRepository, ILogger<GetAllProductQueryHandler> logger = null, ICategoryReadRepository pategoryReadRepository = null, ICategoryReadRepository categoryReadRepository = null)
    {
        _productReadRepository = ProductReadRepository;
        _categoryReadRepository = categoryReadRepository;
        _logger = logger;
    }

    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Products");

        var query = _productReadRepository.GetAll(false).AsQueryable();

        var categoryNameFilter = request.Category;

        if (!string.IsNullOrEmpty(categoryNameFilter))
        {
            if(request.Category == "All")
                query = query.Select(product => product);
            else
                query = query
                .Join(_categoryReadRepository.GetAll(),
                      product => product.CategoryId,
                      category => category.Id,
                      (product, category) => new { Product = product, Category = category })
                .Where(joinResult => joinResult.Category.Name == categoryNameFilter)
                .Select(joinResult => joinResult.Product);
        }

        var totalProductCount = query.Count();

        var Products = query
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.Slug,
                p.CreateDate,
                p.UpdateDate,
                p.ProductImageFiles,
                Category = p.Category.Name
            })
            .ToList();

        return new()
        {
            Products = Products,
            TotalProductCount = totalProductCount
        };
    }
}

public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
    public string Category { get; set; } = "All";
}
public class GetAllProductQueryResponse
{
    public int TotalProductCount { get; set; }
    public object Products { get; set; }
}
