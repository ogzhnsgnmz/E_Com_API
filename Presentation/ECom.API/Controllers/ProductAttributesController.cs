using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.ProductAttribute.CreateProductAttribute;
using ECom.Application.Features.Command.ProductAttribute.RemoveProductAttribute;
using ECom.Application.Features.Command.ProductAttribute.UpdateProductAttribute;
using ECom.Application.Features.Queries.ProductAttribute.GetAllProductAttribute;
using ECom.Application.Features.Queries.ProductAttribute.GetByIdProductAttribute;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAttributesController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductAttributesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get ProductAttributes", Menu = "ProductAttributes")]
        public async Task<IActionResult> GetProductAttributes([FromQuery] GetProductAttributesQueryRequest getProductAttributesQueryRequest)
        {
            GetProductAttributeQueryResponse response = await _mediator.Send(getProductAttributesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get ProductAttribute By Id", Menu = "ProductAttributes")]
        public async Task<IActionResult> GetProductAttributes([FromRoute] GetByIdProductAttributeQueryRequest getProductAttributeByIdQueryRequest)
        {
            GetProductAttributeByIdQueryResponse response = await _mediator.Send(getProductAttributeByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create ProductAttribute", Menu = "ProductAttributes")]
        public async Task<IActionResult> CreateProductAttribute([FromBody] CreateProductAttributeCommandRequest createProductAttributeCommandRequest)
        {
            CreateProductAttributeCommandResponse response = await _mediator.Send(createProductAttributeCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update ProductAttribute", Menu = "ProductAttributes")]
        public async Task<IActionResult> UpdateProductAttribute([FromBody, FromRoute] UpdateProductAttributeCommandRequest updateProductAttributeCommandRequest)
        {
            UpdateProductAttributeCommandResponse response = await _mediator.Send(updateProductAttributeCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete ProductAttribute", Menu = "ProductAttributes")]
        public async Task<IActionResult> DeleteProductAttribute([FromRoute] RemoveProductAttributeCommandRequest removeProductAttributeCommandRequest)
        {
            RemoveProductAttributeCommandResponse response = await _mediator.Send(removeProductAttributeCommandRequest);
            return Ok(response);
        }
    }
}
