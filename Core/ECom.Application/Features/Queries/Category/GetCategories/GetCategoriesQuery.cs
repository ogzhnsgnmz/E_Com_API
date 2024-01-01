using ECom.Application.Features.Queries.Product.GetAllProduct;
using ECom.Application.Repositories.Category;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.Category.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, GetCategoriesQueryResponse>
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository, ILogger<GetAllProductQueryHandler> logger)
    {
        _categoryReadRepository = categoryReadRepository;
        _logger = logger;
    }

    public async Task<GetCategoriesQueryResponse> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Categories");
        var TotalCount = _categoryReadRepository.GetAll(false).Count();
        var Categories = _categoryReadRepository.GetAll(false)
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
            Datas = Categories,
            TotalCount = TotalCount
        };
    }
}
public class GetCategoriesQueryRequest : IRequest<GetCategoriesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetCategoriesQueryResponse
{
    public object Datas { get; set; }
    public int TotalCount { get; set; }
}
