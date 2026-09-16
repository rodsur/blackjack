using NUnit.Framework;

namespace Blackjack.Tests.Kort;

[TestFixture]
[TestOf(typeof(Blackjack.Kort.Kort))]
public class KortTest
{
    [Test]
    public void ToStringTest()
    {
        Blackjack.Kort.Kort kort = new Blackjack.Kort.Kort(Blackjack.Kort.Kort.Værdi.Dronning,Blackjack.Kort.Kort.Kulør.Hjerter);
        Assert.That(kort.ToString(),Is.EqualTo("Hjerter Dronning"));
    }
}