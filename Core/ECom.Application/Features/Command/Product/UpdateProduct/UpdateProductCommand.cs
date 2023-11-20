using ECom.Application.Repositories.Product;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECom.Application.Features.Command.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    readonly IProductReadRepository _ProductReadRepository;
    readonly IProductWriteRepository _ProductWriteRepository;
    readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(IProductReadRepository ProductReadRepository, IProductWriteRepository ProductWriteRepository = null, ILogger<UpdateProductCommandHandler> logger = null)
    {
        _ProductReadRepository = ProductReadRepository;
        _ProductWriteRepository = ProductWriteRepository;
        _logger = logger;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product Product = await _ProductReadRepository.GetByIdAsync(request.Id);
        Product.Name = request.Name;
        Product.Stock = request.Stock;
        Product.Price = request.Price;
        Product.IsOfferable = request.IsOfferable;
        Product.IsSold = Product.IsSold;
        await _ProductWriteRepository.SaveAsync();
        _logger.LogInformation("Ders güncellendi");
        return new();
    }
}
public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public bool IsOfferable { get; set; }
    public bool IsSold { get; set; }
}
public class UpdateProductCommandResponse
{
}
