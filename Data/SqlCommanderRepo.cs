using Commander.Models;

namespace Commander.Data;

public sealed class SqlCommanderRepo(CommanderContext context) : ICommanderRepo
{
    public IEnumerable<Command> GetAllCommands() => context.Commands;

    public Command? GetById(int id) => context.Commands.FirstOrDefault(c => c.Id == id);
}
