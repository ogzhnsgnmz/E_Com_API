using ECom.Application.Abstractions.Services;
using MediatR;

namespace ECom.Application.Features.Command.Basket.RemoveBasketItem
{
    public class RemoveBasketItemCommandHandler : IRequestHandler<RemoveBasketItemCommandRequest, RemoveBasketItemCommandResponse>
    {
        readonly IBasketService _basketService;

        public RemoveBasketItemCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<RemoveBasketItemCommandResponse> Handle(RemoveBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.RemoveBasketItemAsync(request.BasketItemId);
            return new();
        }
    }
    public class RemoveBasketItemCommandRequest : IRequest<RemoveBasketItemCommandResponse>
    {
        public string BasketItemId { get; set; }
    }
    public class RemoveBasketItemCommandResponse
    {
    }
}