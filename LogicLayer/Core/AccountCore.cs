using System.Net.Mail;
using System.Text.RegularExpressions;
using LogicLayer.Cryptography;
using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    public static Account? GetAccount(Account account)
    {
        CheckInit();

        return _accountService.GetFromKey(account).GetAwaiter().GetResult()?[0];
        
    }
    
    public static List<Account>? GetAllAccounts()
    {
        CheckInit();
        
        return _accountService.GetAll().GetAwaiter().GetResult();
    }
    
    public static bool AccountExists(Account account)
    {
        CheckInit();
        
        return GetAccount(account) != null;
    }
    
    public static DatabaseResult AddAccount(Account account)
    {
        CheckInit();
        
        account.Password = PasswordProtector.Protect(account.Password);
        
        return _accountService.Insert(account).GetAwaiter().GetResult();
    }
    
    public static DatabaseResult UpdateAccount(Account account)
    {
        CheckInit();
        
        return _accountService.Update(account).GetAwaiter().GetResult();
    }
    
    public static DatabaseResult InsertAccount(Account account)
    {
        CheckInit();

        return _accountService.Insert(account).GetAwaiter().GetResult();
    }
    
    public static bool ValidateCredentials(Account account, string password)
    {
        CheckInit();
        
        return PasswordProtector.Verify(password, account.Password);
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
        if (username.Length is < 3 or > 20)
        {
            return (false, "Username must be between 3 and 20 characters");
        }
        
        //check if the username is alphanumeric using regex
        if (!UsernameRegex().IsMatch(username))
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
    
    
    
    //regex
    [GeneratedRegex("^[a-zA-Z0-9_-]*$")]
    private static partial Regex UsernameRegex();
}