namespace EuclidUnits;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructorTwoParametersTest()
    {
    
        //arrange
        double x = 1;
        double y = 2;

        //act
        var p = new Point (x, y);

        //assert
        Assert.That(p.X, Is.EqualTo (x));
        Assert.That (p.X, Is.EqualTo (y));
    }
}