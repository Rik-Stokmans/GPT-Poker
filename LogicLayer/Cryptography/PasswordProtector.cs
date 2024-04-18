namespace LogicLayer.Cryptography;

public static class PasswordProtector
{
    public static string Protect(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}