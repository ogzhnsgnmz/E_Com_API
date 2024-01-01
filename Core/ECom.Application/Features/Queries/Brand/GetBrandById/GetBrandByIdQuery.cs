using MediatR;

namespace ECom.Application.Features.Queries.Brand.GetBrandById;

public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQueryRequest, GetBrandByIdQueryResponse>
{
    public Task<GetBrandByIdQueryResponse> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public class GetBrandByIdQueryRequest : IRequest<GetBrandByIdQueryResponse>
{
    public string Id { get; set; }
}
public class GetBrandByIdQueryResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
}