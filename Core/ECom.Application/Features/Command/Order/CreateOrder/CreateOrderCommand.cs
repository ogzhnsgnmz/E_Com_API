using ECom.Application.Abstractions.Hubs;
using ECom.Application.Abstractions.Services;
using ECom.Application.Features.Command.Product.CreateProduct;
using ECom.Application.Repositories.Order;
using ECom.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Features.Command.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly IBasketService _basketService;
        readonly IOrderHubService _orderHubService;

        public CreateOrderCommandHandler(IOrderService orderService, IBasketService basketService, IOrderHubService orderHubService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _orderHubService = orderHubService;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderService.CreateOrderAsync(new()
            {
                Description = request.Description,
                Address = request.Address,
                BasketId = _basketService.GetUserActiveBasket?.Id.ToString(),
                OrderCode = "deneme"
            });

            await _orderHubService.OrderAddedMessageAsync("Yeni bir sipariş geldi!");

            return new();
        }
    }
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public string Description { get; set; } = "Örnek açıklama";
        public string Address { get; set; } = "Örnek adres";
    }
    public class CreateOrderCommandResponse
    {
    }
}
