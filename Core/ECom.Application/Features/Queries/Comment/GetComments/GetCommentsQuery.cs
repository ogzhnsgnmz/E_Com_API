using ECom.Application.Features.Queries.Product.GetAllProduct;
using ECom.Application.Repositories.Comment;
using ECom.Application.Repositories.Product;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Queries.Comment.GetComments;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQueryRequest, GetCommentsQueryResponse>
{
    private readonly ICommentReadRepository _commentReadRepository;
    private readonly IProductReadRepository _productReadRepository;
    readonly ILogger<GetAllProductQueryHandler> _logger;

    public GetCommentsQueryHandler(ICommentReadRepository CommentReadRepository, ILogger<GetAllProductQueryHandler> logger = null, IProductReadRepository productReadRepository = null)
    {
        _commentReadRepository = CommentReadRepository;
        _productReadRepository = productReadRepository;
        _logger = logger;
    }

    public async Task<GetCommentsQueryResponse> Handle(GetCommentsQueryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Get all Products");

        var TotalCount = _commentReadRepository.GetAll(false).Count();
        var Comments = _commentReadRepository.GetAll(false)
            .Skip(request.Page * request.Comment)
            .Take(request.Comment)
            .Select(p => new
            {
                p.Id,
                p.UserName,
                p.Content,
                p.CreateDate,
                p.UpdateDate,
            })
            .ToList();
        return new()
        {
            Datas = Comments,
            TotalCount = TotalCount
        };
    }
}
public class GetCommentsQueryRequest : IRequest<GetCommentsQueryResponse>
{
    public int Page { get; set; }
    public int Comment { get; set; }
    public string ProductId { get; set; }
}
public class GetCommentsQueryResponse
{
    public object Datas { get; set; }
    public int TotalCount { get; set; }
}
