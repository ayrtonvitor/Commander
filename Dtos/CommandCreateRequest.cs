namespace Commander.Dtos;

public sealed record CommandCreateRequest
{
    public string HowTo { get; set; }
    public string Line { get; set; }
    public string Platform { get; set; }
}
