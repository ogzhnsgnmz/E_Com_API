using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Size.DeleteSize
{
    public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeCommandRequest, DeleteSizeCommandResponse>
    {
        public Task<DeleteSizeCommandResponse> Handle(DeleteSizeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class DeleteSizeCommandRequest : IRequest<DeleteSizeCommandResponse>
    {

    }

    public class DeleteSizeCommandResponse
    {

    }
}