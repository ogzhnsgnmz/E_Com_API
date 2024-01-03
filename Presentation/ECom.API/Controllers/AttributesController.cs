using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Attribute.CreateAttribute;
using ECom.Application.Features.Command.Attribute.DeleteAttribute;
using ECom.Application.Features.Command.Attribute.UpdateAttribute;
using ECom.Application.Features.Queries.Attribute.GetAttributeById;
using ECom.Application.Features.Queries.Attribute.GetAttributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        readonly IMediator _mediator;

        public AttributesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Attributes", Menu = "Attributes")]
        public async Task<IActionResult> GetAttributes([FromQuery] GetAttributesQueryRequest getAttributesQueryRequest)
        {
            GetAttributesQueryResponse response = await _mediator.Send(getAttributesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Attribute By Id", Menu = "Attributes")]
        public async Task<IActionResult> GetAttributes([FromRoute] GetAttributeByIdQueryRequest getAttributeByIdQueryRequest)
        {
            GetAttributeByIdQueryResponse response = await _mediator.Send(getAttributeByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Attribute", Menu = "Attributes")]
        public async Task<IActionResult> CreateAttribute([FromBody] CreateAttributeCommandRequest createAttributeCommandRequest)
        {
            CreateAttributeCommandResponse response = await _mediator.Send(createAttributeCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Attribute", Menu = "Attributes")]
        public async Task<IActionResult> UpdateAttribute([FromBody, FromRoute] UpdateAttributeCommandRequest updateAttributeCommandRequest)
        {
            UpdateAttributeCommandResponse response = await _mediator.Send(updateAttributeCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Attribute", Menu = "Attributes")]
        public async Task<IActionResult> DeleteAttribute([FromRoute] DeleteAttributeCommandRequest deleteAttributeCommandRequest)
        {
            DeleteAttributeCommandResponse response = await _mediator.Send(deleteAttributeCommandRequest);
            return Ok(response);
        }
    }
}
