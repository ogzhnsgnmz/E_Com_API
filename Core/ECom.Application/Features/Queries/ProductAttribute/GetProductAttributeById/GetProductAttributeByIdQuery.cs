using ECom.Application.Features.Queries.ProductAttribute.GetAllProductAttribute;
using ECom.Application.Repositories.Attribute;
using ECom.Application.Repositories.ProductAttribute;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.ProductAttribute.GetByIdProductAttribute;

public class GetByIdProductAttributeQueryHandler : IRequestHandler<GetByIdProductAttributeQueryRequest, GetProductAttributeByIdQueryResponse>
{
    readonly IProductAttributeReadRepository _productAttributeReadRepository;
    readonly IAttributeReadRepository _attributeReadRepository;
    readonly ILogger<GetProductAttributeQueryHandler> _logger;

    public GetByIdProductAttributeQueryHandler(IProductAttributeReadRepository ProductAttributeReadRepository, ILogger<GetProductAttributeQueryHandler> logger = null, IAttributeReadRepository attributeReadRepository = null)
    {
        _productAttributeReadRepository = ProductAttributeReadRepository;
        _attributeReadRepository = attributeReadRepository;
        _logger = logger;
    }

    public async Task<GetProductAttributeByIdQueryResponse> Handle(GetByIdProductAttributeQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Products");

        var totalCount = _productAttributeReadRepository.GetAll(false).Count();

        var attributes = _productAttributeReadRepository.GetAll(false)
            .Where(p => p.ProductId == Guid.Parse(request.Id))
            .Select(p => new
            {
                p.Id,
                p.Value,
                p.AttributeId,
                p.CreateDate,
                p.UpdateDate,
            }).ToList();

        var attributeIds = attributes.Select(p => p.AttributeId).ToList();

        var attributeNames = _attributeReadRepository.GetAll(false)
            .Where(a => attributeIds.Contains(a.Id))
            .Select(a => new
            {
                a.Id,
                a.Name
            }).ToList();

        var result = attributes.Join(
            attributeNames,
            attr => attr.AttributeId,
            name => name.Id,
            (attr, name) => new
            {
                attr.Id,
                attr.Value,
                attr.AttributeId,
                AttributeName = name.Name,
                attr.CreateDate,
                attr.UpdateDate,
            }).ToList();

        return new GetProductAttributeByIdQueryResponse
        {
            Datas = result,
            TotalProductAttributeCount = totalCount
        };
    }
}
public class GetByIdProductAttributeQueryRequest : IRequest<GetProductAttributeByIdQueryResponse>
{
    public string Id { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetProductAttributeByIdQueryResponse
{
    public int TotalProductAttributeCount { get; set; }
    public object Datas { get; set; }
}