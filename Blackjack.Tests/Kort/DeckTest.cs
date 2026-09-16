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
    public void BlandTest()
    {
        Deck blandetDeck = new Deck();
        blandetDeck.Bland();
        String kortFraBlandetDeck = blandetDeck.Træk().ToString();
        String kortFraIkkeBlandetDeck = _ikkeBlandetDeck.Træk().ToString();
        Assert.That(kortFraBlandetDeck,Is.Not.EqualTo(kortFraIkkeBlandetDeck));
    }

    [Test]
    public void TrækTest()
    {
        Assert.That(_ikkeBlandetDeck.Træk().ToString(),Is.EqualTo("Hjerter Es"));
    }
}