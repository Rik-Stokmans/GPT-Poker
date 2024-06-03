using LogicLayer.Core;
using LogicLayer.Cryptography;
using LogicLayer.Models;
using UnitTests.MockData;

namespace UnitTests;

public class CoreTests
{

    [SetUp]
    public void Setup()
    {
        var accounts = new List<Account>();

        for (int i = 0; i < 10; i++)
        {
            var id = i;
            var username = "Player " + i;
            var email = "Test" + i + "@mail.com";
            var password = PasswordProtector.Protect("password" + i);
            var lives = i > 5 ? 5 : i;

            accounts.Add(new Account(id, username, email, password, lives));
        }


        var units = new List<Unit>();

        for (int i = 1; i <= 25; i++)
        {
            var id = i;
            var sectionId = (i - 1) / 5 + 1;
            var placeInSection = (i - 1) % 5 + 1;
            var name = "Unit " + placeInSection;

            units.Add(new Unit(id, sectionId, placeInSection, name));
        }


        var sections = new List<Section>();

        for (int i = 1; i <= 5; i++)
        {
            var id = i;
            var name = "Section " + i;

            sections.Add(new Section(id, name));
        }



        var accountService = new MockDataService<Account>(accounts);
        var sectionService = new MockDataService<Section>(sections);
        var unitService = new MockDataService<Unit>(units);
        var lessonService = new MockDataService<Lesson>(new List<Lesson>());
        var sectionProgressService = new MockDataService<SectionProgress>(new List<SectionProgress>());
        var unitProgressService = new MockDataService<UnitProgress>(new List<UnitProgress>());
        var lessonProgressService = new MockDataService<LessonProgress>(new List<LessonProgress>());

        Core.Init(accountService, sectionService, unitService, lessonService, sectionProgressService,
            unitProgressService, lessonProgressService);
    }



    [Test]
    public void GetFromKeyTest()
    {
        var account = Core.GetAccount(new Account(email: "Test3@mail.com"));

        if (account == null)
        {
            Assert.Fail("Player not found");
            return;
        }

        if (account.Id != 3) Assert.Fail("Player Id is not 3");
        if (account.Username != "Player 3") Assert.Fail("Player Username is not Player 3");

        Assert.Pass();
    }

    [Test]
    public void InsertTest()
    {
        var newAccount = new Account(10, "Test10@gmail.com", "Player 10", PasswordProtector.Protect("password10"), 5);

        Core.InsertAccount(newAccount);

        if (Core.GetAllAccounts().ToList().Contains(newAccount)) Assert.Pass();
        else Assert.Fail("Player not inserted or not found");


    }

    [Test]
    public void UpdateTest()
    {
        var account = Core.GetAccount(new Account(id: 3));

        if (account == null)
        {
            Assert.Fail("Player not found");
            return;
        }

        var accountCopy = new Account(account.Id, "Player 3 Updated", account.Email, account.Password, account.Lives);

        Core.UpdateAccount(accountCopy);

        if (Core.GetAllAccounts().ToList().Contains(accountCopy)) Assert.Pass();
        else Assert.Fail("Player not updated or not found");
    }

    [Test]
    public void EmailValidationTest()
    {
        Dictionary<string, bool> emails = new Dictionary<string, bool>
        {
            // Valid emails
            { "john.doe@example.com", true },
            { "jane_smith123@domain.org", true },
            { "user.name@sub.domain.com", true },
            { "user+mailbox@domain.co.uk", true },
            { "firstname.lastname@domain.com", true },
            { "email@domain.com", true },
            { "1234567890@domain.com", true },
            { "email@domain-one.com", true },
            { "_______@domain.com", true },
            { "email@domain.name", true },
            { "email@domain.co.jp", true },
            { "firstname-lastname@domain.com", true },
            { "no-tld@domain", true },
            // Invalid emails
            { "plainaddress", false },
            { "@no-local-part.com", false },
            { "no-at.domain.com", false },
            { ";beginning-semicolon@domain.co.uk", false },
            { "middle-semicolon@domain.co;uk", false },
            { "trailing-semicolon@domain.com;", false },
            { "\"email+leading-quotes@domain.com", false }
        };

        foreach (var keyValuePair in emails)
        {
            var email = keyValuePair.Key;
            var valid = keyValuePair.Value;

            if (Core.IsValidEmail(email) != valid)
            {
                Assert.Fail("Email validation failed for " + email);
                return;
            }
        }
        
        Assert.Pass();
    }

    [Test]
    public void UsernameValidationTest()
    {
        Dictionary<string, bool> usernames = new Dictionary<string, bool>
        {
            // Valid usernames
            { "alice123", true },
            { "charlie_brown", true },
            { "emmawatson", true },
            { "frankie4real", true },
            { "gracehopper", true },
            { "harrypotter", true },
            { "isabella1989", true },
            { "jacksparrow", true },
            { "karen123", true },
            { "lisamarie", true },
            { "michaeljordan", true },
            { "natalieportman", true },
            { "olivertwist", true },

            // Invalid usernames
            { "a", false }, // Too short
            { "ab", false }, // Too short
            { "toolongusernamefortestpurpose", false }, // Too long
            { "123username", false }, // Starts with a number
            { "_underscorestart", false }, // Starts with an underscore
            { "-dashstart", false }, // Starts with a dash
            { ".dotstart", false }, // Starts with a dot
            { "username!", false }, // Contains special character
            { "user name", false }, // Contains space
            { "user__name", false }, // Consecutive underscores
            { "user--name", false }, // Consecutive hyphens
            { "user..name", false }, // Consecutive dots
            { "username_", false } // Ends with an underscore
        };

        foreach (var keyValuePair in usernames)
        {
            if (Core.IsValidUsername(keyValuePair.Key).valid != keyValuePair.Value)
            {
                Assert.Fail("Username validation failed for " + keyValuePair.Key);
                return;
            }
            
            Assert.Pass();
        }
    }
    
    
}
















