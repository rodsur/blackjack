using Blackjack.Grænseflade;
using Blackjack.KortNS;
using Blackjack.SpilNS;

namespace Blackjack;

class Program
{
    static void Main(string[] args)
    {
        IGrænseflade grænseflade = new TekstGrænseflade();
        ISpiller dealer = new Spiller();
        ISpiller spiller = new Spiller();
        IDeck deck = new Deck();
        Spil spil = new Spil(grænseflade, dealer, spiller, deck);
        spil.SpilLoop();
    }
}