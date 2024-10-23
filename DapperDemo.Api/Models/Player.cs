namespace DapperDemo.Api.Models;

public class Player
{
    public int Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public int Age { get; set; }
}
