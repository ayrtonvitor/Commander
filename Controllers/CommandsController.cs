using Commander.Data;
using Commander.Dtos;
using Commander.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController(ICommanderRepo repository) : ControllerBase
{
    private readonly CommandMapper _mapper = new();
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

    [HttpPost]
    public ActionResult<CommandReadResponse> CreateCommand(CommandCreateRequest commandCreateRequest)
    {
        var commandModel = _mapper.CommandCreateRequestToCommand(commandCreateRequest);
        repository.Create(commandModel);
        repository.SaveChanges();
        return Ok(_mapper.CommandToCommandReadResponse(commandModel));
    }
}
