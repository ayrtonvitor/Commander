using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos;

public sealed record CommandCreateRequest
{
    [Required]
    [MaxLength(255)]
    public string HowTo { get; set; }

    [Required]
    [MaxLength(255)]
    public string Line { get; set; }

    [Required]
    [MaxLength(255)]
    public string Platform { get; set; }
}
