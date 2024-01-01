using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Brand.CreateBrand;
using ECom.Application.Features.Command.Brand.DeleteBrand;
using ECom.Application.Features.Command.Brand.UpdateBrand;
using ECom.Application.Features.Queries.Brand.GetBrandById;
using ECom.Application.Features.Queries.Brand.GetBrands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Brands", Menu = "Brands")]
        public async Task<IActionResult> GetBrands([FromQuery] GetBrandsQueryRequest getBrandsQueryRequest)
        {
            GetBrandsQueryResponse response = await _mediator.Send(getBrandsQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Brand By Id", Menu = "Brands")]
        public async Task<IActionResult> GetBrands([FromRoute] GetBrandByIdQueryRequest getBrandByIdQueryRequest)
        {
            GetBrandByIdQueryResponse response = await _mediator.Send(getBrandByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Brand", Menu = "Brands")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommandRequest createBrandCommandRequest)
        {
            CreateBrandCommandResponse response = await _mediator.Send(createBrandCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Brand", Menu = "Brands")]
        public async Task<IActionResult> UpdateBrand([FromBody, FromRoute] UpdateBrandCommandRequest updateBrandCommandRequest)
        {
            UpdateBrandCommandResponse response = await _mediator.Send(updateBrandCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Brand", Menu = "Brands")]
        public async Task<IActionResult> DeleteBrand([FromRoute] DeleteBrandCommandRequest deleteBrandCommandRequest)
        {
            DeleteBrandCommandResponse response = await _mediator.Send(deleteBrandCommandRequest);
            return Ok(response);
        }
    }
}
