using ECom.Application.CustomAttributes;
using ECom.Application.Enums;
using ECom.Application.Features.Command.Address.CreateAddress;
using ECom.Application.Features.Command.Address.DeleteAddress;
using ECom.Application.Features.Command.Address.UpdateAddress;
using ECom.Application.Features.Queries.Address.GetAddressById;
using ECom.Application.Features.Queries.Address.GetAddresses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Addresses", Menu = "Addresses")]
        public async Task<IActionResult> GetAddresses([FromQuery] GetAddressesQueryRequest getAddressesQueryRequest)
        {
            GetAddressesQueryResponse response = await _mediator.Send(getAddressesQueryRequest);
            return Ok(response);
        }

        [HttpGet("{userName}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Address By userName", Menu = "Addresses")]
        public async Task<IActionResult> GetAddresses([FromRoute] GetAddressByIdQueryRequest getAddressByIdQueryRequest)
        {
            GetAddressByIdQueryResponse response = await _mediator.Send(getAddressByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Address", Menu = "Addresses")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommandRequest createAddressCommandRequest)
        {
            CreateAddressCommandResponse response = await _mediator.Send(createAddressCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Address", Menu = "Addresses")]
        public async Task<IActionResult> UpdateAddress([FromBody, FromRoute] UpdateAddressCommandRequest updateAddressCommandRequest)
        {
            UpdateAddressCommandResponse response = await _mediator.Send(updateAddressCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Address", Menu = "Addresses")]
        public async Task<IActionResult> DeleteAddress([FromRoute] DeleteAddressCommandRequest deleteAddressCommandRequest)
        {
            DeleteAddressCommandResponse response = await _mediator.Send(deleteAddressCommandRequest);
            return Ok(response);
        }
    }
}
