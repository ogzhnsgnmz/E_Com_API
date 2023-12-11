﻿using ECom.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    readonly IProductReadRepository _ProductReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetAllProductQueryHandler(IProductReadRepository ProductReadRepository, ILogger<GetAllProductQueryHandler> logger = null)
    {
        _ProductReadRepository = ProductReadRepository;
        _logger = logger;
    }


    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Products");
        var totalProductCount = _ProductReadRepository.GetAll(false).Count();
        var Products = _ProductReadRepository.GetAll(false)
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate,
                p.ProductImageFiles
            }).ToList();

        return new()
        {
            Products = Products,
            TotalProductCount = totalProductCount
        };
    }
}

public class GetAllProductQueryRequest : IRequest<GetAllProductQueryResponse>
{
    //public Pagination Pagination { get; set; }
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
public class GetAllProductQueryResponse
{
    public int TotalProductCount { get; set; }
    public object Products { get; set; }
}
