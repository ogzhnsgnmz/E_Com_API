using ECom.Application.Repositories.Comment;
using ECom.Application.Repositories.Size;
using MediatR;

namespace ECom.Application.Features.Queries.Comment.GetCommentById;

public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQueryRequest, GetCommentByIdQueryResponse>
{
    readonly ICommentReadRepository _commentReadRepository;

    public GetCommentByIdQueryHandler(ICommentReadRepository commentReadRepository)
    {
        _commentReadRepository = commentReadRepository;
    }

    public async Task<GetCommentByIdQueryResponse> Handle(GetCommentByIdQueryRequest request, CancellationToken cancellationToken)
    {

        var TotalCount = _commentReadRepository.GetAll(false).Where(p => p.ProductId == Guid.Parse(request.ProductId)).Count();
        var Comments = _commentReadRepository.GetAll(false)
            //.Skip(request.Page * request.Size)
            //.Take(request.Size)
            .Where(p => p.ProductId == Guid.Parse(request.ProductId))
            .Select(p => new
            {
                p.Id,
                p.Content,
                p.UserName,
                p.Ratings,
                p.CreateDate,
            }).ToList();

        double avrRating = Comments.Any() ? Math.Round(Comments.Average(p => p.Ratings), 2) : 0;

        return new()
        {
            Datas = Comments,
            AvrRating = avrRating,
            TotalCount = TotalCount
        };
    }
}
public class GetCommentByIdQueryRequest : IRequest<GetCommentByIdQueryResponse>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public string ProductId { get; set; }
}
public class GetCommentByIdQueryResponse
{
    public object Datas { get; set; }
    public int TotalCount { get; set; }
    public double AvrRating { get; set; }
}