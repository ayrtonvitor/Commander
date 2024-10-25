using Commander.Models;

namespace Commander.Data;

public sealed class SqlCommanderRepo(CommanderContext context) : ICommanderRepo
{
    public IEnumerable<Command> GetAllCommands() => context.Commands;

    public Command? GetById(int id) => context.Commands.FirstOrDefault(c => c.Id == id);

    public void Create(Command cmd)
    {
        if (cmd is null)
        {
            throw new ArgumentNullException(nameof(cmd));
        }
        context.Commands.Add(cmd);
    }

    public bool SaveChanges() => context.SaveChanges() >= 0;
}
