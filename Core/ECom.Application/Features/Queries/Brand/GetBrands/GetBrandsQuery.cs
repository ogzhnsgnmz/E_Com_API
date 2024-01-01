using ECom.Application.Features.Queries.Product.GetAllProduct;
using ECom.Application.Repositories.Brand;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.Brand.GetBrands;

public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQueryRequest, GetBrandsQueryResponse>
{
    private readonly IBrandReadRepository _brandReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetBrandsQueryHandler(IBrandReadRepository brandReadRepository, ILogger<GetAllProductQueryHandler> logger)
    {
        _brandReadRepository = brandReadRepository;
        _logger = logger;
    }

    public async Task<GetBrandsQueryResponse> Handle(GetBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Brands");
        var TotalCount = _brandReadRepository.GetAll(false).Count();
        var Brands = _brandReadRepository.GetAll(false)
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
            Datas = Brands,
            TotalCount = TotalCount
        };
    }
}
public class GetBrandsQueryRequest : IRequest<GetBrandsQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetBrandsQueryResponse
{
    public object Datas { get; set; }
    public int TotalCount { get; set; }
}
