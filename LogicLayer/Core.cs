using System.Net.Mail;
using System.Text.RegularExpressions;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using LogicLayer.Cryptography;

namespace LogicLayer;

public static partial class Core
{

    public enum Result
    {
        Success,
        Fail,
        Duplicate
    }

    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static IDatabaseEntityService<Player> _playerService = null!;
    private static bool _initialized;
    
    public static void Init(IDatabaseEntityService<Player> playerService)
    {
        _playerService = playerService;
        _initialized = true;
    }
    
    
    public static List<Player>? GetAllPlayers()
    {
        CheckInit();
        
        return _playerService.GetAll().GetAwaiter().GetResult();
    }
    
    public static Player? GetPlayer(Player player)
    {
        CheckInit();
        
        return _playerService.GetFromKey(player).GetAwaiter().GetResult();
    }
    
    public static bool PlayerExists(Player player)
    {
        CheckInit();
        
        return GetPlayer(player) != null;
    }
    
    public static Result AddPlayer(Player player)
    {
        CheckInit();
        
        player.Password = PasswordProtector.Protect(player.Password);
        
        return _playerService.Insert(player).GetAwaiter().GetResult();
    }
    
    public static bool ValidateCredentials(Player player, string password)
    {
        CheckInit();
        
        return PasswordProtector.Verify(password, player.Password);
    }
    
    public static bool IsValidEmail(string email)
    {
        try
        {
            // ReSharper disable once UnusedVariable
            var m = new MailAddress(email);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    
    public static string FormatEmail(string email)
    {
        return string.Concat(email[..email.IndexOf('@')].Replace(".", ""), email.AsSpan(email.IndexOf('@'))).ToLower();
    }

    public static (bool valid, string message) IsValidUsername(string username)
    {
        //check if the username is valid
        if (username.Length is < 5 or > 20)
        {
            return (false, "Username must be between 5 and 20 characters");
        }
        
        //check if the username is alphanumeric using regex
        if (!MyRegex().IsMatch(username))
        {
            return (false, "Username can only contain letters and numbers");
        }
        
        //check if the username starts with a letter
        if (!char.IsLetter(username[0]))
        {
            return (false, "Username must start with a letter");
        }
        
        return (true, "");
    }
    
    
    
    //Private methods
    private static void CheckInit()
    {
        if (!_initialized) throw new Exception("Core not initialized");
    }
    
    
    
    //regex
    [GeneratedRegex("^[a-zA-Z0-9]*$")]
    private static partial Regex MyRegex();
}