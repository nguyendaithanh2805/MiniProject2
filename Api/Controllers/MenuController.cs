using Abstraction.Commands;
using Abstractions.Queries;
using Api.ApiResponses;
using Application.Commands.Menus;
using Application.DTOs;
using Application.Exceptions;
using Application.Queries.Menus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public MenuController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            try
            {
                return Ok(new ApiResponse<IEnumerable<MenuDto>>(true, "Get all menus successfully",
                    await _queryDispatcher.QueryAsync(new GetAllMenusQuery())));
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
                    await _queryDispatcher.QueryAsync(new GetMenuByIdQuery(id))));
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
                await _commandDispatcher.SendAsync(command);
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

                await _commandDispatcher.SendAsync(command);
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
                await _commandDispatcher.SendAsync(command);
                return Ok(new ApiResponse<string>(true, $"Menu with id {id} has been deleted successfully.", null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(true, ex.Message, null));
            }
        }
    }
}
