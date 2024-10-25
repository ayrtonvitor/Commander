using Commander.Data;
using Commander.Dtos;
using Commander.Mappers;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController(ICommanderRepo repository) : ControllerBase
{
    private readonly CommandMapper _mapper = new CommandMapper();
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadResponse>> GetAllCommands()
    {
        var commandItems = repository.GetAllCommands();
        return Ok(_mapper.CommandToCommandReadResponse(commandItems));
    }

    [HttpGet("{id:int}")]
    public ActionResult<CommandReadResponse> GetCommandById(int id)
    {
        var commandItem = repository.GetById(id);
        if (commandItem == null)
        {
            return NotFound();
        }
        return Ok(_mapper.CommandToCommandReadResponse(commandItem));
    }
}
