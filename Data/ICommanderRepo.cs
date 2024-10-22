using Commander.Models;

namespace Commander.Data;

internal interface ICommanderRepo
{
    IEnumerable<Command> GetAllCommands();
    Command GetById(int id);
}
