using ECom.Application.Repositories.ProductAttribute;
using MediatR;

namespace ECom.Application.Features.Queries.ProductAttribute.GetByIdProductAttribute;

public class GetByIdProductAttributeQueryHandler : IRequestHandler<GetByIdProductAttributeQueryRequest, GetProductAttributeByIdQueryResponse>
{
    readonly IProductAttributeReadRepository _ProductAttributeReadRepository;

    public GetByIdProductAttributeQueryHandler(IProductAttributeReadRepository ProductAttributeReadRepository)
    {
        _ProductAttributeReadRepository = ProductAttributeReadRepository;
    }

    public async Task<GetProductAttributeByIdQueryResponse> Handle(GetByIdProductAttributeQueryRequest request, CancellationToken cancellationToken)
    {
        return new();
    }
}
public class GetByIdProductAttributeQueryRequest : IRequest<GetProductAttributeByIdQueryResponse>
{
    public string Id { get; set; }
}
public class GetProductAttributeByIdQueryResponse
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public bool IsOfferable { get; set; }
    public bool IsSold { get; set; }
}