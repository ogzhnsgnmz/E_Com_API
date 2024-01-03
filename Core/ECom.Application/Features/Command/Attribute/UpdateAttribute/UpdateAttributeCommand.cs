using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Attribute.UpdateAttribute
{
    public class UpdateAttributeCommandHandler : IRequestHandler<UpdateAttributeCommandRequest, UpdateAttributeCommandResponse>
    {
        public Task<UpdateAttributeCommandResponse> Handle(UpdateAttributeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class UpdateAttributeCommandRequest : IRequest<UpdateAttributeCommandResponse>
    {

    }

    public class UpdateAttributeCommandResponse
    {

    }
}