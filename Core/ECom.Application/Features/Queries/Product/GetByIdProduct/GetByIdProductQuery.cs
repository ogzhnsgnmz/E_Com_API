using ECom.Application.Repositories.Product;
using MediatR;

namespace ECom.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        readonly IProductReadRepository _ProductReadRepository;

        public GetByIdProductQueryHandler(IProductReadRepository ProductReadRepository)
        {
            _ProductReadRepository = ProductReadRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Product Product = await _ProductReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Name = Product.Name,
                Practical = Product.Practical,
                AKTS = Product.AKTS,
                Code = Product.Code,
                Theoric = Product.Theoric
            };
        }
    }
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public string Id { get; set; }
    }
    public class GetByIdProductQueryResponse
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Theoric { get; set; }
        public string Practical { get; set; }
        public string AKTS { get; set; }
    }
}
