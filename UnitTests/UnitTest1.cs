namespace UnitTests;

public class Tests
{
    
    [SetUp]
    public void Setup()
    {
        // This is a comment
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
}

public class Tests2
{
    
    [SetUp]
    public void Setup()
    {
        // This is a comment
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
}