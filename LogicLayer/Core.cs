using LogicLayer.Interfaces;
using LogicLayer.Models;
using BCrypt.Net;
using LogicLayer.Cryptography;

namespace LogicLayer;

public static class Core
{

    public enum Result
    {
        Succes,
        Fail,
        Duplicate
    }

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
    
    
    //Private methods
    private static void CheckInit()
    {
        if (!_initialized) throw new Exception("Core not initialized");
    }
    
    
}