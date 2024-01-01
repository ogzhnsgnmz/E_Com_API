using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Category.CreateCategory;
using ECom.Application.Features.Command.Category.DeleteCategory;
using ECom.Application.Features.Command.Category.UpdateCategory;
using ECom.Application.Features.Queries.Category.GetCategoryById;
using ECom.Application.Features.Queries.Category.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Categories", Menu = "Categories")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategoriesQueryRequest getCategoriesQueryRequest)
        {
            GetCategoriesQueryResponse response = await _mediator.Send(getCategoriesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Category By Id", Menu = "Categories")]
        public async Task<IActionResult> GetCategories([FromRoute] GetCategoryByIdQueryRequest getCategoryByIdQueryRequest)
        {
            GetCategoryByIdQueryResponse response = await _mediator.Send(getCategoryByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Category", Menu = "Categories")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Category", Menu = "Categories")]
        public async Task<IActionResult> UpdateCategory([FromBody, FromRoute] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Category", Menu = "Categories")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            DeleteCategoryCommandResponse response = await _mediator.Send(deleteCategoryCommandRequest);
            return Ok(response);
        }
    }
}
