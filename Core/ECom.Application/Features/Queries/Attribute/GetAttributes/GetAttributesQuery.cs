using ECom.Application.Features.Queries.Product.GetAllProduct;
using ECom.Application.Repositories.Attribute;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.Attribute.GetAttributes;

public class GetAttributesQueryHandler : IRequestHandler<GetAttributesQueryRequest, GetAttributesQueryResponse>
{
    private readonly IAttributeReadRepository _attributeReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetAttributesQueryHandler(IAttributeReadRepository AttributeReadRepository, ILogger<GetAllProductQueryHandler> logger)
    {
        _attributeReadRepository = AttributeReadRepository;
        _logger = logger;
    }

    public async Task<GetAttributesQueryResponse> Handle(GetAttributesQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Attributes");
        var TotalCount = _attributeReadRepository.GetAll(false).Count();
        var Attributes = _attributeReadRepository.GetAll(false)
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.CreateDate,
                p.UpdateDate,
            }).ToList();

        return new()
        {
            Datas = Attributes,
            TotalCount = TotalCount
        };
    }
}
public class GetAttributesQueryRequest : IRequest<GetAttributesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetAttributesQueryResponse
{
    public object Datas { get; set; }
    public int TotalCount { get; set; }
}
