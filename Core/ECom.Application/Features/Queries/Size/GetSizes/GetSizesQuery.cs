using ECom.Application.Features.Queries.Product.GetAllProduct;
using ECom.Application.Repositories.Size;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.Size.GetSizes;

public class GetSizesQueryHandler : IRequestHandler<GetSizesQueryRequest, GetSizesQueryResponse>
{
    private readonly ISizeReadRepository _sizeReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetSizesQueryHandler(ISizeReadRepository sizeReadRepository, ILogger<GetAllProductQueryHandler> logger = null)
    {
        _sizeReadRepository = sizeReadRepository;
        _logger = logger;
    }

    public async Task<GetSizesQueryResponse> Handle(GetSizesQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Products");
        var TotalCount = _sizeReadRepository.GetAll(false).Count();
        var Sizes = _sizeReadRepository.GetAll(false)
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
            Datas = Sizes,
            TotalCount = TotalCount
        };
    }
}
public class GetSizesQueryRequest : IRequest<GetSizesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetSizesQueryResponse
{
    public object Datas { get; set; }
    public int TotalCount { get; set; }
}
