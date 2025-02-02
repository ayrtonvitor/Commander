using Commander.Models;

namespace Commander.Data;

public interface ICommanderRepo
{
    IEnumerable<Command> GetAllCommands();
    Command? GetById(int id);
    void Create(Command cmd);
    bool SaveChanges();
}
