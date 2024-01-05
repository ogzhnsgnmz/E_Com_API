using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Comment.CreateComment;
using ECom.Application.Features.Command.Comment.DeleteComment;
using ECom.Application.Features.Command.Comment.UpdateComment;
using ECom.Application.Features.Queries.Comment.GetCommentById;
using ECom.Application.Features.Queries.Comment.GetComments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Comments", Menu = "Comments")]
    public async Task<IActionResult> GetComments([FromQuery] GetCommentsQueryRequest getCommentsQueryRequest)
    {
        GetCommentsQueryResponse response = await _mediator.Send(getCommentsQueryRequest);
        return Ok(response);
    }

    [HttpGet("{productId}")]
    [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Comment By Id", Menu = "Comments")]
    public async Task<IActionResult> GetComments([FromRoute] GetCommentByIdQueryRequest getCommentByIdQueryRequest)
    {
        GetCommentByIdQueryResponse response = await _mediator.Send(getCommentByIdQueryRequest);
        return Ok(response);
    }

    [HttpPost]
    [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Comment", Menu = "Comments")]
    public async Task<IActionResult> CreateComment(CreateCommentCommandRequest createCommentCommandRequest)
    {
        CreateCommentCommandResponse response = await _mediator.Send(createCommentCommandRequest);
        return Ok(response);
    }

    [HttpPut("{Id}")]
    [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Comment", Menu = "Comments")]
    public async Task<IActionResult> UpdateComment([FromBody, FromRoute] UpdateCommentCommandRequest updateCommentCommandRequest)
    {
        UpdateCommentCommandResponse response = await _mediator.Send(updateCommentCommandRequest);
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Comment", Menu = "Comments")]
    public async Task<IActionResult> DeleteComment([FromRoute] DeleteCommentCommandRequest deleteCommentCommandRequest)
    {
        DeleteCommentCommandResponse response = await _mediator.Send(deleteCommentCommandRequest);
        return Ok(response);
    }
}
