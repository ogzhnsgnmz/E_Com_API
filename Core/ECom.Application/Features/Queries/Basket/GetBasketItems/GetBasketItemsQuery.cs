﻿using ECom.Application.Abstractions.Services;
using MediatR;

namespace ECom.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, List<GetBasketItemsQueryResponse>>
    {
        readonly IBasketService _basketService;

        public GetBasketItemsQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<List<GetBasketItemsQueryResponse>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var basketItem = await _basketService.GetBasketItemsAsync();
            return basketItem.Select(ba => new GetBasketItemsQueryResponse
            {
                BasketItemId = ba.Id.ToString(),
                Name = ba.Product.Name,
                Price = ba.Product.Price,
                Quantity = ba.Quantity
            }).ToList();
        }
    }
    public class GetBasketItemsQueryRequest : IRequest<List<GetBasketItemsQueryResponse>>
    {
    }
    public class GetBasketItemsQueryResponse
    {
        public string BasketItemId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

    }
}
