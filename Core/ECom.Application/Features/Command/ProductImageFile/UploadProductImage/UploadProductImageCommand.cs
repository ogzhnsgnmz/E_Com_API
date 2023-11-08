using ECom.Application.Abstractions.Storage;
using ECom.Application.Repositories.Product;
using ECom.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        readonly IProductReadRepository _ProductReadRepository;
        readonly IProductImageFileWriteRepository _ProductImageFileWriteRepository;
        readonly IStorageService _storageService;

        public UploadProductImageCommandHandler(IProductReadRepository ProductReadRepository)
        {
            _ProductReadRepository = ProductReadRepository;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            Domain.Product Product = await _ProductReadRepository.GetByIdAsync(request.Id);

            await _ProductImageFileWriteRepository.AddRangeAsync(result.Select(r => new C.ProductImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                storage = _storageService.StorageName,
                Products = new List<C.Product>() { Product }
            }).ToList());

            await _ProductImageFileWriteRepository.SaveAsync();
            return new();
        }
    }
    public class UploadProductImageCommandRequest : IRequest<UploadProductImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
    public class UploadProductImageCommandResponse
    {
    }
}
