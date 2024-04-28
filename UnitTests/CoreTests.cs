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
        
        Core.Init(accountService, sectionService, unitService, lessonService, sectionProgressService, unitProgressService, lessonProgressService);
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
}
















