using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers;

[Route("api/[controller]")]
[ApiController]
internal class CommandsController(ICommanderRepo repository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
        var commandItems = repository.GetAppCommands();
        return Ok(commandItems);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Command> GetCommandById(int id)
    {
        var commandItem = repository.GetById(id);
        return Ok(commandItem);
    }
}
