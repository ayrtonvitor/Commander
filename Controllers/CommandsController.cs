using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController(ICommanderRepo _repository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
        var commandItems = _repository.GetAppCommands();
        return Ok(commandItems);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Command> GetCommandById(int id)
    {
        var commandItem = _repository.GetById(id);
        return Ok(commandItem);
    }
}
