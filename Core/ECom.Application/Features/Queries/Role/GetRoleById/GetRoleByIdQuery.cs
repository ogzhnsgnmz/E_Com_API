using ECom.Application.Abstractions.Services;
using MediatR;

namespace ECom.Application.Features.Queries.Role.GetRoleById;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryRequest, GetRoleByIdQueryResponse>
{
    readonly IRoleService _roleService;

    public GetRoleByIdQueryHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<GetRoleByIdQueryResponse> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var data = await _roleService.GetRoleById(request.Id);
        return new()
        {
            Id = data.id,
            Name = data.name
        };
    }
}
public class GetRoleByIdQueryRequest : IRequest<GetRoleByIdQueryResponse>
{
    public string Id { get; set; }
}
public class GetRoleByIdQueryResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
}