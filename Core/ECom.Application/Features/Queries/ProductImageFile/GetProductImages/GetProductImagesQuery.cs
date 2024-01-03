using ECom.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ECom.Application.Features.Queries.ProductImageFile.GetProductImages;

public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, List<GetProductImagesQueryResponse>>
{
    readonly IProductReadRepository _ProductReadRepository;
    readonly IConfiguration _configuration;

    public GetProductImagesQueryHandler(IProductReadRepository ProductReadRepository, IConfiguration configuration = null)
    {
        _ProductReadRepository = ProductReadRepository;
        _configuration = configuration;
    }

    public async Task<List<GetProductImagesQueryResponse>> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product? Product = await _ProductReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

        var response = Product?.ProductImageFiles.Select(p => new GetProductImagesQueryResponse
        {
            Path = $"{_configuration["BaseStorageUrl"]}/{p.Path}",
            FileName = p.FileName,
            Id = p.Id
        }).ToList();

        return response;
    }
}
public class GetProductImagesQueryRequest : IRequest<List<GetProductImagesQueryResponse>>
{
    public string Id { get; set; }
}
public class GetProductImagesQueryResponse
{
    public Guid Id { get; set; }
    public string Path { get; set; }
    public string FileName { get; set; }
}
