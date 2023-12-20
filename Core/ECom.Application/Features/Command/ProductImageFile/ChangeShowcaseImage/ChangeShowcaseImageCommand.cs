using ECom.Application.Repositories.ProductImageFile;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECom.Application.Features.Command.ProductImageFile.ChangeShowcaseImage;

public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
{
    readonly IProductImageFileWriteRepository _productImageFileWriteRepositry;

    public ChangeShowcaseImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepositry)
    {
        _productImageFileWriteRepositry = productImageFileWriteRepositry;
    }

    public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
    {
        var query = _productImageFileWriteRepositry.Table
            .Include(p => p.Products)
            .SelectMany(p => p.Products, (pif, p) => new
            {
                pif,
                p
            });

        var data = await query
            .FirstOrDefaultAsync(p => p.p.Id == Guid.Parse(request.ProductId) && p.pif.Showcase);

        if(data != null)
            data.pif.Showcase = false;

        var image = await query.
            FirstOrDefaultAsync(p => p.pif.Id == Guid.Parse(request.ImageId));
        
        if (image != null)
            image.pif.Showcase = true;

        await _productImageFileWriteRepositry.SaveAsync();

        return new();
    }
}
public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>
{
    public string ImageId { get; set; }
    public string ProductId { get; set; }
}
public class ChangeShowcaseImageCommandResponse
{
}
