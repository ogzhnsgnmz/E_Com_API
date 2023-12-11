using ECom.Application.Features.Command.Basket.AddItemToBasket;
using ECom.Application.Features.Command.Basket.RemoveBasketItem;
using ECom.Application.Features.Command.Basket.UpdateQuantity;
using ECom.Application.Features.Queries.Basket.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class BasketsController : ControllerBase
{
    readonly IMediator _mediator;

    public BasketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest request)
         => Ok(await _mediator.Send(request));

    [HttpGet]
    public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest request)
         => Ok(await _mediator.Send(request));

    [HttpPut]
    public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest request)
         => Ok(await _mediator.Send(request));

    [HttpDelete("{BasketItemId}")]
    public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest request)
         => Ok(await _mediator.Send(request));
}
