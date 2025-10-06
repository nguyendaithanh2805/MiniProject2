using Abstraction.Commands;
using Api.ApiResponses;
using Application.Commands.Menus;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/menus")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public MenuController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
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
