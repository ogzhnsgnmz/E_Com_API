using ECom.Application.Repositories.Product;
using MediatR;

namespace ECom.Application.Features.Queries.Product.GetByIdProduct;

public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
{
    readonly IProductReadRepository _ProductReadRepository;

    public GetByIdProductQueryHandler(IProductReadRepository ProductReadRepository)
    {
        _ProductReadRepository = ProductReadRepository;
    }

    public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product Product = await _ProductReadRepository.GetByIdAsync(request.Id, false);
        return new()
        {
            Name = Product.Name,
            Stock = Product.Stock,
            Price = Product.Price,
            Description = Product.Description,
            Slug = Product.Slug
        };
    }
}
public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
{
    public string Id { get; set; }
}
public class GetByIdProductQueryResponse
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public bool IsOfferable { get; set; }
    public bool IsSold { get; set; }
}