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
    [Route("api/menus")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            try
            {
                return Ok(new ApiResponse<IEnumerable<MenuDto>>(true, "Get all menus successfully",
                    await _mediator.Send(new GetAllMenusQuery())));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMenuById([FromRoute] int id)
        {
            try
            {
                return Ok(new ApiResponse<MenuDto>(true, "Get menu successfully",
                    await _mediator.Send(new GetMenuByIdQuery(id))));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu(AddMenuCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok(new ApiResponse<string>(true, "Menu created successfully", null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMenu([FromRoute] int id, [FromBody] UpdateMenuCommand command)
        {
            try
            {
                if (id != command.Id)
                    return BadRequest("Id in route and body must match.");

                await _mediator.Send(command);
                return Ok(new ApiResponse<string>(true, "Menu updated successfully.", null));
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
        public async Task<IActionResult> DeleteMenu([FromRoute] int id)
        {
            try
            {
                var command = new RemoveMenuCommand { Id = id };
                await _mediator.Send(command);
                return Ok(new ApiResponse<string>(true, $"Menu with id {id} has been deleted successfully.", null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }
    }
}
