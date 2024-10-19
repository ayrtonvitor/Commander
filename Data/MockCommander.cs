using Commander.Models;

namespace Commander.Data;

internal sealed class MockCommander : ICommanderRepo
{
    public IEnumerable<Command> GetAppCommands()
    {
        var commands = new List<Command>
        {
            new() { Id = 0, HowTo = "Read a book", Line = "Read the words", Platform = "Chair" },
            new() { Id = 1, HowTo = "Hi fi a croc", Line = "Don't", Platform = "Swap" },
            new() { Id = 2, HowTo = "Hugh a gorilla", Line = "Just don't get up", Platform = "Jungle" }
        };
        return commands;
    }

    public Command GetById(int id)
    {
        return new Command { Id = 0, HowTo = "Read a book", Line = "Read the words", Platform = "Chair" };
    }
}
