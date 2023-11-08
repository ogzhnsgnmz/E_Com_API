using ECom.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponse>
    {
        readonly IProductReadRepository _ProductReadRepository;
        readonly IProductWriteRepository _ProductWriteRepository;

        public RemoveProductImageCommandHandler(IProductReadRepository ProductReadRepository, IProductWriteRepository ProductWriteRepository = null)
        {
            _ProductReadRepository = ProductReadRepository;
            _ProductWriteRepository = ProductWriteRepository;
        }

        public async Task<RemoveProductImageCommandResponse> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Product? Product = await _ProductReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            Domain.ProductImageFile? ProductImageFile = Product?.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (ProductImageFile != null)
                Product?.ProductImageFiles.Remove(ProductImageFile);

            await _ProductWriteRepository.SaveAsync();
            return new();
        }
    }
    public class RemoveProductImageCommandRequest : IRequest<RemoveProductImageCommandResponse>
    {
        public string Id { get; set; }
        public string? ImageId { get; set; }
    }
    public class RemoveProductImageCommandResponse
    {
    }
}
