using System;
using Blackjack.KortNS;
using NUnit.Framework;

namespace Blackjack.Tests.Kort;
[TestFixture]
[TestOf(typeof(Deck))]
public class DeckTest
{
    private Deck _ikkeBlandetDeck;
    
    [SetUp]
    public void Setup()
    {
        _ikkeBlandetDeck = new Deck();
    }

    [Test]
    public void TrækTest()
    {
        Assert.That(_ikkeBlandetDeck.Træk().ToString(),Is.EqualTo("Hjerter Es"));
    }

    [Test]
    public void TrækForMangeKortTest()
    {

        Assert.Throws<InvalidOperationException>(() =>
        {
            while(true)
            {
                _ikkeBlandetDeck.Træk();
            }
        });
    }
}