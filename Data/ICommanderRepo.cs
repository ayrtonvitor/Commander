using Commander.Models;

namespace Commander.Data;

internal interface ICommanderRepo
{
    IEnumerable<Command> GetAppCommands();
    Command GetById(int id);
}
