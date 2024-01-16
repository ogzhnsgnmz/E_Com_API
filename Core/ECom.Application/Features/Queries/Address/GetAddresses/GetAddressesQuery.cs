using MediatR;

namespace ECom.Application.Features.Queries.Address.GetAddresses;

public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQueryRequest, GetAddressesQueryResponse>
{

    public async Task<GetAddressesQueryResponse> Handle(GetAddressesQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public class GetAddressesQueryRequest : IRequest<GetAddressesQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Address { get; set; } = 5;
}
public class GetAddressesQueryResponse
{
    public object Datas { get; set; }
    public int TotalCount { get; set; }
}
