using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicLayer.Models;

public class Account
{
    public Account(int id, string username, string email, string password, int lives)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
        Lives = lives;
    }

    public Account(int id = 0, string? email = null, string? username = null)
    {
        Id = id;
        if (email != null) Email = email;
        if (username != null) Username = username;
    }

    public Account()
    {
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [Key]
    public string Username { get; set; } = null!;

    [Key]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Lives { get; set; }
}