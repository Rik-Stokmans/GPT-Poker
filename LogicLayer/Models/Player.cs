using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicLayer.Models;

public class Player
{
    public Player(int id, string username, string email, string password, int lives)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        Lives = lives;
    }

    public Player(int id, string? email = null)
    {
        Id = id;
        if (email != null) Email = email;
    }

    public Player()
    {
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    public string Username { get; set; } = null!;

    [Key]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Lives { get; set; }
}