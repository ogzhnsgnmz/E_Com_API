using ECom.Application.Abstractions.Services;
using ECom.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, GetRolesQueryResponse>
    {
        readonly IRoleService _roleService;

        public GetRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetRolesQueryResponse> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var (datas, count) = _roleService.GetAllRoles(request.Page, request.Size);
            return new()
            {
                Datas = datas,
                TotalCount = count
            };
        }
    }
    public class GetRolesQueryRequest : IRequest<GetRolesQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
    public class GetRolesQueryResponse
    {
        public object Datas { get; set; }
        public int TotalCount { get; set; }
    }
}
