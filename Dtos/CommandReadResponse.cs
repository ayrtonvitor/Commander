namespace Commander.Dtos;

public sealed record CommandReadResponse
{
    public int Id { get; set; }
    public string HowTo { get; set; }
    public string Line { get; set; }
}
