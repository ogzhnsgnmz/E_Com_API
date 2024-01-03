using ECom.Application.Consts;
using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Product.CreateProduct;
using ECom.Application.Features.Command.Product.RemoveProduct;
using ECom.Application.Features.Command.Product.UpdateProduct;
using ECom.Application.Features.Command.ProductImageFile.ChangeShowcaseImage;
using ECom.Application.Features.Command.ProductImageFile.RemoveProductImage;
using ECom.Application.Features.Command.ProductImageFile.UploadProductImage;
using ECom.Application.Features.Queries.Product.GetAllProduct;
using ECom.Application.Features.Queries.Product.GetByIdProduct;
using ECom.Application.Features.Queries.ProductImageFile.GetProductImages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        => Ok(await _mediator.Send(getAllProductQueryRequest));

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        => Ok(await _mediator.Send(getByIdProductQueryRequest));

    [HttpPost]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Create Product")]
    public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
    {
        CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
    public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        => Ok(await _mediator.Send(updateProductCommandRequest));

    [HttpDelete("{Id}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product")]
    public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        => Ok(await _mediator.Send(removeProductCommandRequest));

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product File")]
    public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
    {
        uploadProductImageCommandRequest.Files = Request.Form.Files;
        UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
        return Ok();
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
        => Ok(await _mediator.Send(getProductImagesQueryRequest));

    [HttpDelete("[action]/{Id}")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product Image")]
    public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest,
        [FromQuery] string imageId)
    {
        removeProductImageCommandRequest.ImageId = imageId;
        RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);
        return Ok();
    }

    [HttpGet("[action]")]
    [Authorize(AuthenticationSchemes = "Admin")]
    [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Change Showcase Image")]
    public async Task<IActionResult> ChangeShowCaseImage([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        => Ok(await _mediator.Send(changeShowcaseImageCommandRequest));
}
