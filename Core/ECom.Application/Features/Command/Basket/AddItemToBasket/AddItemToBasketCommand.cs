using ECom.Application.Abstractions.Services;
using MediatR;

namespace ECom.Application.Features.Command.Basket.AddItemToBasket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public AddItemToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.AddItemToBasketAsync(new()
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity
            });

            return new();
        }
    }
    public class AddItemToBasketCommandRequest : IRequest<AddItemToBasketCommandResponse>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class AddItemToBasketCommandResponse
    {
    }
}