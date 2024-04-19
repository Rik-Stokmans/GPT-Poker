using LogicLayer.Core;
using LogicLayer.Models;
using UnitTests.MockData;

namespace UnitTests;

public class CoreTests
{
    private readonly List<Account> _accounts = 
    [
        new Account
        {
            Id = 1,
            Username = "Player 1",
            Email = "Test1@mail.com",
            Password = "passwordTest1",
            Lives = 3
        },

        new Account
        {
            Id = 2,
            Username = "Player 2",
            Email = "Test2@mail.com",
            Password = "passwordTest2",
            Lives = 1
        },

        new Account
        {
            Id = 3,
            Username = "Player 3",
            Email = "Test3@mail.com",
            Password = "passwordTest3",
            Lives = 0
        },

        new Account
        {
            Id = 4,
            Username = "Player 4",
            Email = "Test4@mail.com",
            Password = "passwordTest4",
            Lives = 2
        },

        new Account
        {
            Id = 5,
            Username = "Player 5",
            Email = "Test5@mail.com",
            Password = "passwordTest5",
            Lives = 5
        }
    ];
    
    
    [SetUp]
    public void Setup()
    {
        var accountService = new MockDataService<Account>(_accounts);
        
        Core.Init(accountService);
    }
    
    

    [Test]
    public void GetFromKeyTest()
    {
        var account = Core.GetAccount(new Account(0, "Test3@mail.com"));
        
        
        if (account == null)
        {
            Assert.Fail("Player not found");
            return;
        }
        
        
        if (account.Id != 3) Assert.Fail("Player Id is not 3");
        if (account.Username != "Player 3") Assert.Fail("Player Username is not Player 3");
        
        Assert.Pass();
        
    }
}
















