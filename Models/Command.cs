using System.ComponentModel.DataAnnotations;

namespace Commander.Models;

public sealed class Command(int id, string howTo, string line, string platform)
{
    [Key]
    public int Id { get; set; } = id;

    [Required, MaxLength(255)]
    public string HowTo { get; set; } = howTo;

    [Required, MaxLength(255)]
    public string Line { get; set; } = line;

    [Required, MaxLength(255)]
    public string  Platform { get; set; } = platform;
}
