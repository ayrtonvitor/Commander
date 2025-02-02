using Commander.Models;

namespace Commander.Data;

public sealed class MockCommander : ICommanderRepo
{
    public IEnumerable<Command> GetAllCommands()
    {
        var commands = new List<Command?>
        {
            new(0, "Read a book", "Read the words","Chair"),
            new(1, "Hi fi a croc", "Don't", "Swap"),
            new(2, "Hugh a gorilla", "Just don't get up", "Jungle")
        };
        return commands;
    }

    public Command? GetById(int id)
    {
        return new Command (0, "Read a book", "Read the words", "Chair");
    }

    public void Create(Command cmd)
    {
        throw new NotImplementedException();
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }
}
