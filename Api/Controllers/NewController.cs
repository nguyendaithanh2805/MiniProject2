using Api.ApiResponses;
using Application.Commands;
using Application.DTOs;
using Application.Exceptions;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(new ApiResponse<IEnumerable<NewsDto>>(true, "Get all news successfully",
                    await _mediator.Send(new GetAllNewsQuery())));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(new ApiResponse<NewsDto>(true, "Get new successfully",
                    await _mediator.Send(new GetNewByIdQuery(id))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu(AddNewCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok(new ApiResponse<string>(true, "New created successfully", null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateNewCommand command)
        {
            try
            {
                if (id != command.Id)
                    return BadRequest("Id in route and body must match.");

                await _mediator.Send(command);
                return Ok(new ApiResponse<string>(true, "New updated successfully.", null));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(true, ex.Message, null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var command = new RemoveNewCommand { Id = id };
                await _mediator.Send(command);
                return Ok(new ApiResponse<string>(true, $"New with id {id} has been deleted successfully.", null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }
    }
}
