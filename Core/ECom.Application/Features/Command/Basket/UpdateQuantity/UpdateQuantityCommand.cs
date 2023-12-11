using ECom.Application.Abstractions.Services;
using MediatR;

namespace ECom.Application.Features.Command.Basket.UpdateQuantity
{
    public class GetBasketItemsQueryHandler : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
    {
        readonly IBasketService _basketService;

        public GetBasketItemsQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.UpdateQuantityAsync(new()
            {
                BasketItemId = int.Parse(request.BasketItemId),
                Quantity = request.Quantity,
            });
            return new();
        }
    }
    public class UpdateQuantityCommandRequest : IRequest<UpdateQuantityCommandResponse>
    {
        public string BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
    public class UpdateQuantityCommandResponse
    {
    }
}