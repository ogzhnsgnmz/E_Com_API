using MediatR;

namespace ECom.Application.Features.Queries.Attribute.GetAttributeById;

public class GetAttributeByIdQueryHandler : IRequestHandler<GetAttributeByIdQueryRequest, GetAttributeByIdQueryResponse>
{
    public Task<GetAttributeByIdQueryResponse> Handle(GetAttributeByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public class GetAttributeByIdQueryRequest : IRequest<GetAttributeByIdQueryResponse>
{
    public string Id { get; set; }
}
public class GetAttributeByIdQueryResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
}