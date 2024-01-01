using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Size.CreateSize;
using ECom.Application.Features.Command.Size.DeleteSize;
using ECom.Application.Features.Command.Size.UpdateSize;
using ECom.Application.Features.Queries.Size.GetSizeById;
using ECom.Application.Features.Queries.Size.GetSizes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        readonly IMediator _mediator;

        public SizesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Sizes", Menu = "Sizes")]
        public async Task<IActionResult> GetSizes([FromQuery] GetSizesQueryRequest getSizesQueryRequest)
        {
            GetSizesQueryResponse response = await _mediator.Send(getSizesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Size By Id", Menu = "Sizes")]
        public async Task<IActionResult> GetSizes([FromRoute] GetSizeByIdQueryRequest getSizeByIdQueryRequest)
        {
            GetSizeByIdQueryResponse response = await _mediator.Send(getSizeByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Size", Menu = "Sizes")]
        public async Task<IActionResult> CreateSize([FromBody] CreateSizeCommandRequest createSizeCommandRequest)
        {
            CreateSizeCommandResponse response = await _mediator.Send(createSizeCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Size", Menu = "Sizes")]
        public async Task<IActionResult> UpdateSize([FromBody, FromRoute] UpdateSizeCommandRequest updateSizeCommandRequest)
        {
            UpdateSizeCommandResponse response = await _mediator.Send(updateSizeCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Size", Menu = "Sizes")]
        public async Task<IActionResult> DeleteSize([FromRoute] DeleteSizeCommandRequest deleteSizeCommandRequest)
        {
            DeleteSizeCommandResponse response = await _mediator.Send(deleteSizeCommandRequest);
            return Ok(response);
        }
    }
}
