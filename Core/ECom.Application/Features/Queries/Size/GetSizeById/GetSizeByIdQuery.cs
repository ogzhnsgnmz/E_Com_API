using MediatR;

namespace ECom.Application.Features.Queries.Size.GetSizeById;

public class GetSizeByIdQueryHandler : IRequestHandler<GetSizeByIdQueryRequest, GetSizeByIdQueryResponse>
{
    public Task<GetSizeByIdQueryResponse> Handle(GetSizeByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public class GetSizeByIdQueryRequest : IRequest<GetSizeByIdQueryResponse>
{
    public string Id { get; set; }
}
public class GetSizeByIdQueryResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
}