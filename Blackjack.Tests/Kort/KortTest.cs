using NUnit.Framework;

namespace Blackjack.Tests.Kort;

[TestFixture]
[TestOf(typeof(Blackjack.KortNS.Kort))]
public class KortTest
{
    [Test]
    public void ToStringTest()
    {
        KortNS.Kort kort = new KortNS.Kort(KortNS.Kort.Værdi.Dronning, KortNS.Kort.Kulør.Hjerter);
        Assert.That(kort.ToString(),Is.EqualTo("Hjerter Dronning"));
    }
}