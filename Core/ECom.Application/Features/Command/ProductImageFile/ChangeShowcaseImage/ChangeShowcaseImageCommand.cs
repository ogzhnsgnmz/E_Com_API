using MediatR;

namespace ECom.Application.Features.Command.ProductImageFile.ChangeShowcaseImage;

public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
{
    public Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>
{
}
public class ChangeShowcaseImageCommandResponse
{
}
