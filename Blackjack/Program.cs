using Blackjack.Grænseflade;
using Blackjack.SpilNS;

namespace Blackjack;

class Program
{
    static void Main(string[] args)
    {
        Spil spil = new Spil();
        spil.SpilLoop();
    }
}