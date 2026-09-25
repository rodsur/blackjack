using System.Collections.Generic;
using Blackjack.Grænseflade;
using Blackjack.KortNS;
using Blackjack.SpilNS;
using NUnit.Framework;

namespace Blackjack.Tests.Spil;

[TestFixture]
[TestOf(typeof(SpilNS.Spil))]
public class SpilTest
{
    private List<KortNS.Kort> _hånd;
    private SpilNS.Spil _spil;
    
    [SetUp]
    public void Setup()
    {
        _hånd = [];
        _spil = new SpilNS.Spil(new TekstGrænseflade(), new Spiller(), new Spiller(), new Deck());
    }

    [Test]
    public void Udregnhånd5plus5Test()
    {
        
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Fem, KortNS.Kort.Kulør.Klør));
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Fem, KortNS.Kort.Kulør.Hjerter));
        Assert.That(_spil.UdregnHånd(_hånd),Is.EqualTo(10));
    }
    
    [Test]
    public void UdregnhåndBilledKortTest()
    {
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Dronning, KortNS.Kort.Kulør.Klør));
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Konge, KortNS.Kort.Kulør.Hjerter));
        Assert.That(_spil.UdregnHånd(_hånd),Is.EqualTo(20));
    }
    
    [Test]
    public void UdregnhåndTestEsSom11()
    {
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Ti, KortNS.Kort.Kulør.Klør));
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Es, KortNS.Kort.Kulør.Hjerter));
        Assert.That(_spil.UdregnHånd(_hånd),Is.EqualTo(21));
    }
    [Test]
    public void UdregnhåndTestEsSom1()
    {
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.To, KortNS.Kort.Kulør.Klør));
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Knægt, KortNS.Kort.Kulør.Klør));
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Es, KortNS.Kort.Kulør.Hjerter));
        Assert.That(_spil.UdregnHånd(_hånd),Is.EqualTo(13));
    }
    
    [Test]
    public void UdregnhåndTestFlereEs()
    {
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Es, KortNS.Kort.Kulør.Klør));
        _hånd.Add(new KortNS.Kort(KortNS.Kort.Værdi.Es, KortNS.Kort.Kulør.Hjerter));
        Assert.That(_spil.UdregnHånd(_hånd),Is.EqualTo(22));
    }
    
}