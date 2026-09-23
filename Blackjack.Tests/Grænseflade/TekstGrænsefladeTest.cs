using System;
using System.IO;
using Blackjack.Grænseflade;
using NUnit.Framework;

namespace Blackjack.Tests.Grænseflade;

[TestFixture]
[TestOf(typeof(TekstGrænseflade))]
public class TekstGrænsefladeTest
{
    private TekstGrænseflade _grænseflade;
    private StringWriter _stringWriter;
    private StringReader _stringReader;
    
    [SetUp]
    public void Setup()
    {
        _grænseflade = new TekstGrænseflade();
        _stringWriter = new StringWriter();
        
        Console.SetOut(_stringWriter);
    }

    [Test]
    public void SkrivBesked_BeskedIndOgBeskedUdErEnsUdoverWhitespaceTest()
    {
        String testString = "Test besked";
        _grænseflade.SkrivBesked(testString);
        Assert.That(_stringWriter.ToString().Trim(), Is.EqualTo(testString));
    }

    [Test]
    public void PræsenterValg_ForventetFlowTest()
    {
        _stringReader = new StringReader("1");
        Console.SetIn(_stringReader);
        Assert.That(_grænseflade.PræsenterValg("Besked", 2),Is.EqualTo(1));
    }
    
    [Test]
    public void PræsenterValg_InputForHøjtTest()
    {
        _stringReader = new StringReader("3\n2");
        Console.SetIn(_stringReader);
        _grænseflade.PræsenterValg("", 2);
        Assert.That(_stringWriter.ToString(),Does.Contain("Ugyldigt valg"));
    }
    
    [Test]
    public void PræsenterValg_InputForLavtTest()
    {
        _stringReader = new StringReader("-1\n2");
        Console.SetIn(_stringReader);
        _grænseflade.PræsenterValg("", 2);
        Assert.That(_stringWriter.ToString(),Does.Contain("Ugyldigt valg"));
    }
    
    [Test]
    public void PræsenterValg_InputErNullTest()
    {
        _stringReader = new StringReader("");
        Console.SetIn(_stringReader);
        Assert.Throws<NullReferenceException>(() => _grænseflade.PræsenterValg("",2));
    }
}