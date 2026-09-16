using System.Collections.Generic;
using NUnit.Framework;

namespace Blackjack.Tests;

[TestFixture]
[TestOf(typeof(Spil))]
public class SpilTest
{
    private List<KortNS.Kort> hånd;
    private Spil spil;
    [SetUp]
    public void Setup()
    {
        hånd = [];
        spil = new Spil();
    }

    [Test]
    public void Udregnhånd5plus5Test()
    {
        
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Fem, KortNS.Kort.Kulør.Klør));
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Fem, KortNS.Kort.Kulør.Hjerter));
        Assert.That(spil.UdregnHånd(hånd),Is.EqualTo(10));
    }
    
    [Test]
    public void UdregnhåndBilledKortTest()
    {
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Dronning, KortNS.Kort.Kulør.Klør));
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Konge, KortNS.Kort.Kulør.Hjerter));
        Assert.That(spil.UdregnHånd(hånd),Is.EqualTo(20));
    }
    
    [Test]
    public void UdregnhåndTestEsSom11()
    {
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Ti, KortNS.Kort.Kulør.Klør));
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Es, KortNS.Kort.Kulør.Hjerter));
        Assert.That(spil.UdregnHånd(hånd),Is.EqualTo(21));
    }
    [Test]
    public void UdregnhåndTestEsSom1()
    {
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.To, KortNS.Kort.Kulør.Klør));
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Knægt, KortNS.Kort.Kulør.Klør));
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Es, KortNS.Kort.Kulør.Hjerter));
        Assert.That(spil.UdregnHånd(hånd),Is.EqualTo(13));
    }
    
    [Test]
    public void UdregnhåndTestFlereEs()
    {
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Es, KortNS.Kort.Kulør.Klør));
        hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Es, KortNS.Kort.Kulør.Hjerter));
        Assert.That(spil.UdregnHånd(hånd),Is.EqualTo(22));
    }
    
}