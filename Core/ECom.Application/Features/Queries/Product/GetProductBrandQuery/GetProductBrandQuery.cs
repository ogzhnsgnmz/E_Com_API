using ECom.Application.Features.Queries.ProductAttribute.GetAllProductAttribute;
using ECom.Application.Repositories.Brand;
using ECom.Application.Repositories.Product;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECom.Application.Features.Queries.Product.GetProductBrandQuery
{
    public class GetProductBrandQueryHandler : IRequestHandler<GetProductBrandQueryRequest, GetProductBrandQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IBrandReadRepository _brandReadRepository;

        public GetProductBrandQueryHandler(IProductReadRepository productReadRepository, IBrandReadRepository brandReadRepository)
        {
            _productReadRepository = productReadRepository;
            _brandReadRepository = brandReadRepository;
        }

        public async Task<GetProductBrandQueryResponse> Handle(GetProductBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var brandId = _brandReadRepository
                .GetAll()
                .Where(p => p.Name.ToLower() == request.Brand.ToLower())
                .Select(a => a.Id)
                .FirstOrDefault();

            var products = _productReadRepository
                .GetAll()
                .Where(p => p.BrandId == brandId)
                .ToList();


            var totalCount = products.Count;

            return new GetProductBrandQueryResponse
            {
                Products = products,
                TotalCount = totalCount
            };
        }
    }

    public class GetProductBrandQueryRequest : IRequest<GetProductBrandQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
        public string Brand { get; set; }
    }

    public class GetProductBrandQueryResponse
    {
    public int TotalCount { get; set; }
    public object Products { get; set; }
    }
}
