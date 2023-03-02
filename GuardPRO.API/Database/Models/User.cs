using System.ComponentModel.DataAnnotations.Schema;

namespace GuardPRO.API.Database.Models;

public class User
{
    public int Id { get; set; }
    public string Sername { get; set; }
    public string Name { get; set; }
    public string Patronic { get; set; }
    public string Telephone { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime DateOfBird { get; set; }

    public string SerialPassport { get; set; }
    public string NumberPassport { get; set; }

    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<Group> Groups { get; set; }
}