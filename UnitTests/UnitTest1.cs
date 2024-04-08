namespace UnitTests;

public class Tests
{
    
    
    
    [SetUp]
    public void Setup()
    {
        
    }
    
    [Test]
    public void PassTest()
    {
        Assert.Pass();
    }
    
    [Test]
    public void FailTest()
    {
        Assert.Fail();
    }
    
    [Test]
    public void InconclusiveTest()
    {
        Assert.Inconclusive();
    }
}