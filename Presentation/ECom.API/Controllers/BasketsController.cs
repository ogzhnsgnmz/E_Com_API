using ECom.Application.Consts;
using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Basket.AddItemToBasket;
using ECom.Application.Features.Command.Basket.RemoveBasketItem;
using ECom.Application.Features.Command.Basket.UpdateQuantity;
using ECom.Application.Features.Queries.Basket.GetBasketItems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Writing, Definition = "Add Item To Basket")]

    public async Task<IActionResult> AddItemToBasket(AddItemToBasketCommandRequest request)
         => Ok(await _mediator.Send(request));

    [HttpGet]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Reading, Definition = "Get Basket Items")]
    public async Task<IActionResult> GetBasketItems([FromQuery] GetBasketItemsQueryRequest request)
         => Ok(await _mediator.Send(request));

    [HttpPut]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Updating, Definition = "Update Quantity")]
    public async Task<IActionResult> UpdateQuantity(UpdateQuantityCommandRequest request)
         => Ok(await _mediator.Send(request));

    [HttpDelete("{BasketItemId}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Baskets, ActionType = ActionType.Deleting, Definition = "Remove Basket Item")]

    public async Task<IActionResult> RemoveBasketItem([FromRoute] RemoveBasketItemCommandRequest request)
         => Ok(await _mediator.Send(request));
}
