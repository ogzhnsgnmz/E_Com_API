using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Size.UpdateSize
{
    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommandRequest, UpdateSizeCommandResponse>
    {
        public Task<UpdateSizeCommandResponse> Handle(UpdateSizeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class UpdateSizeCommandRequest : IRequest<UpdateSizeCommandResponse>
    {

    }

    public class UpdateSizeCommandResponse
    {

    }
}