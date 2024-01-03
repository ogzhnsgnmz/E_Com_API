using ECom.Application.Repositories.Attribute;
using ECom.Application.Repositories.ProductAttribute;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ECom.Application.Features.Queries.ProductAttribute.GetAllProductAttribute;

public class GetProductAttributeQueryHandler : IRequestHandler<GetProductAttributesQueryRequest, GetProductAttributeQueryResponse>
{
    readonly IProductAttributeReadRepository _productAttributeReadRepository;
    readonly IAttributeReadRepository _attributeReadRepository;
    readonly ILogger<GetProductAttributeQueryHandler> _logger;

    public GetProductAttributeQueryHandler(IProductAttributeReadRepository ProductAttributeReadRepository, ILogger<GetProductAttributeQueryHandler> logger = null, IAttributeReadRepository attributeReadRepository = null)
    {
        _productAttributeReadRepository = ProductAttributeReadRepository;
        _attributeReadRepository = attributeReadRepository;
        _logger = logger;
    }

    public async Task<GetProductAttributeQueryResponse> Handle(GetProductAttributesQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Products");

        var totalCount = _productAttributeReadRepository.GetAll(false).Count();

        var attributes = _productAttributeReadRepository.GetAll(false)
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .Select(p => new
            {
                p.Id,
                p.Value,
                AttributeId = p.AttributeId,
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

        return new GetProductAttributeQueryResponse
        {
            Datas = result,
            TotalProductAttributeCount = totalCount
        };
    }
}

public class GetProductAttributesQueryRequest : IRequest<GetProductAttributeQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetProductAttributeQueryResponse
{
    public int TotalProductAttributeCount { get; set; }
    public object Datas { get; set; }
}