using ECom.Application.Abstractions.Storage;
using ECom.Application.Repositories.Product;
using ECom.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECom.Application.Features.Command.ProductImageFile.UploadProductImage;

public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
{
    readonly IProductReadRepository _ProductReadRepository;
    readonly IProductImageFileWriteRepository _ProductImageFileWriteRepository;
    readonly IStorageService _storageService;

    public UploadProductImageCommandHandler(IProductReadRepository ProductReadRepository, IStorageService storageService, IProductImageFileWriteRepository productImageFileWriteRepository)
    {
        _ProductReadRepository = ProductReadRepository;
        _storageService = storageService;
        _ProductImageFileWriteRepository = productImageFileWriteRepository;
    }

    public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("product-images", request.Files);

        Domain.Entities.Product Product = await _ProductReadRepository.GetByIdAsync(request.Id);

        await _ProductImageFileWriteRepository.AddRangeAsync(result.Select(r => new Domain.Entities.ProductImageFile
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Products = new List<Domain.Entities.Product>() { Product }
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
