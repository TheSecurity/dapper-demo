namespace DapperDemo.Api.Models;

public class PlayerUpdateModel
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public int Age { get; set; }
}
