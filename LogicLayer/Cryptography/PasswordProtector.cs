namespace LogicLayer.Cryptography;

public static class PasswordProtector
{
    public static string Protect(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    
    public static bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}