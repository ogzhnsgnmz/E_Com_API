﻿using ECom.Application.Consts;
using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Order.CompleteOrder;
using ECom.Application.Features.Command.Order.CreateOrder;
using ECom.Application.Features.Queries.Order.GetAllOrders;
using ECom.Application.Features.Queries.Order.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class OrdersController : ControllerBase
{
    readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get Order By Id")]
    public async Task<ActionResult> GetOrderById([FromRoute] GetOrderByIdQueryRequest getOrderByIdQueryRequest)
    {
        GetOrderByIdQueryResponse response = await _mediator.Send(getOrderByIdQueryRequest);
        return Ok(response);
    }

    [HttpGet]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Gel All Orders")]
    public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest getAllOrdersQueryRequest)
    {
        GetAllOrdersQueryResponse response = await _mediator.Send(getAllOrdersQueryRequest);
        return Ok(response);
    } 
    [HttpPost]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition = "Create Order")]
    public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest createOrderCommandRequest)
    {
        CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
        return Ok(response);
    }

    [HttpGet("complete-order/{Id}")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Updating, Definition = "Complete Order")]
    public async Task<IActionResult> CompleteOrder([FromRoute] CompleteOrderCommandRequest completeOrderCommandRequest)
    {
        CompleteOrderCommandResponse response = await _mediator.Send(completeOrderCommandRequest);
        return Ok(response);
    }
}
