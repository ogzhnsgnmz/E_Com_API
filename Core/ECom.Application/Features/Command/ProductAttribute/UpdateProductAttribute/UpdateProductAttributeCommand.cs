using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.ProductAttribute.UpdateProductAttribute
{
    public class UpdateProductAttributeCommandHandler : IRequestHandler<UpdateProductAttributeCommandRequest, UpdateProductAttributeCommandResponse>
    {
        public Task<UpdateProductAttributeCommandResponse> Handle(UpdateProductAttributeCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class UpdateProductAttributeCommandRequest : IRequest<UpdateProductAttributeCommandResponse>
    {

    }

    public class UpdateProductAttributeCommandResponse
    {

    }
}