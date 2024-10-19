namespace Commander.Models;

public class Command
internal sealed class Command(int id, string howTo, string line, string platform)
{
    public int Id { get; set; }
    public string HowTo { get; set; }
    public string Line { get; set; }
    public string  Platform { get; set; }
}
