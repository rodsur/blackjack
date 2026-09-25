using Blackjack.SpilNS;
using NUnit.Framework;

namespace Blackjack.Tests.Spil;

[TestFixture]
[TestOf(typeof(Spiller))]
public class SpillerTest
{

    [Test]
    public void TilføjKortAntalTest()
    {
        Spiller spiller = new Spiller();
        KortNS.Kort kort = new KortNS.Kort(KortNS.Kort.Værdi.Dronning, KortNS.Kort.Kulør.Hjerter);
        spiller.TilføjKort(kort);
        Assert.That(spiller.GetROHånd().Count,Is.EqualTo(1));
    }
}