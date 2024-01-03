using ECom.Application.Features.Queries.Product.GetAllProduct;
using ECom.Application.Repositories.Brand;
using ECom.Application.Repositories.Category;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.Category.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetCategoryByIdQueryHandler(ICategoryReadRepository categoryReadRepository, ILogger<GetAllProductQueryHandler> logger)
    {
        _categoryReadRepository = categoryReadRepository;
        _logger = logger;
    }

    public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
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
                p.Slug,
                p.CreateDate,
                p.UpdateDate,
            }).ToList();

        return new()
        {
            Categories = Categories,
            TotalCount = TotalCount
        };
    }
}
public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetCategoryByIdQueryResponse
{
    public object Categories { get; set; }
    public int TotalCount { get; set; }
}