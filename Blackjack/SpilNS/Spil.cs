using System.Collections.ObjectModel;
using System.Text;
using Blackjack.Grænseflade;
using Blackjack.KortNS;

namespace Blackjack.SpilNS;

public class Spil
{
    private List<ISpiller> spillere;
    private ISpiller dealer;
    private ISpiller spiller;
    private IDeck deck;
    private IGrænseflade grænseflade;

    public Spil()
    {
        grænseflade = new TekstGrænseflade();
        spillere = new List<ISpiller>();
        dealer = new Spiller();
        spiller = new Spiller();
        deck = new Deck();
        deck.Bland();
        UddelStartKort();
    }
    
    public void SpilLoop()
    {
        bool spilIgang = true;
        while (spilIgang)
        {
            OplysSpillerOmKortOgVærdi();
            int brugerValg = HitEllerStand();
            switch (brugerValg)
            {
                case 1:
                    UddelKortTilSpiller(spiller);
                    if (UdregnHånd(spiller) > 21)
                    {
                        grænseflade.SkrivBesked("Du har mere end 21 point, du har tabt");
                        spilIgang = false;
                    } else if (UdregnHånd(spiller) == 21)
                    {
                        grænseflade.SkrivBesked("Du fik 21, tillykke du har vundet!");
                    }
                    break;
                case 2:
                    int spillerPoint = UdregnHånd(spiller);
                    int dealerPoint = UdregnHånd(dealer);
                    if (dealerPoint > spillerPoint)
                    {
                        grænseflade.SkrivBesked("Du tabte til dealeren");
                    } else if (spillerPoint > dealerPoint)
                    {
                        grænseflade.SkrivBesked("Tillykke du vandt over dealeren");
                    }
                    else
                    {
                        grænseflade.SkrivBesked("I stod lige, bedre held næste gang");
                    }

                    spilIgang = false;
                    break;
            }
        }
    }

    private int HitEllerStand()
    {
        StringBuilder outputString = new StringBuilder();
        outputString.Append("Du har nu følgende valgmuligheder:\n" +
                            "1 Hit\n" +
                            "2 Stand\n" +
                            "Hvad ønsker du at gøre?");
        return grænseflade.PræsenterValg(outputString.ToString(),2);
    }

    private void OplysSpillerOmKortOgVærdi()
    {
        StringBuilder outputString = new StringBuilder();
        outputString.Append("Dealeren har følgende kort:\n");
        foreach (var kort in dealer.GetROHånd())
        {
            outputString.Append(kort + "\n");
        }
        outputString.Append("Dealerens kort har en værdi på: " + UdregnHånd(dealer) + "\n");
        outputString.Append("Du har følgende kort:\n");
        foreach (var kort in spiller.GetROHånd())
        {
            outputString.Append(kort + "\n");
        }
        outputString.Append("Díne kort har en værdi på: " + UdregnHånd(spiller) + "\n");
        grænseflade.SkrivBesked(outputString.ToString());
    }

    public int UdregnHånd(List<Kort> hånd)
    {
        int håndVærdi = 0;
        int esVærdi = 0;
        foreach (var kort in hånd)
        {
            switch (kort.getVærdi())
            {
                case Kort.Værdi.Es:
                    if (esVærdi != 0) {
                        håndVærdi += esVærdi;
                    } else {
                        esVærdi = UdregnEsVærdi(esVærdi, håndVærdi);
                        håndVærdi += esVærdi;
                    }
                    break;
                case Kort.Værdi.Konge:
                case Kort.Værdi.Dronning:
                case Kort.Værdi.Knægt:
                    håndVærdi += 10;
                    break;
                default:
                    håndVærdi += (int)kort.getVærdi();
                    break;
            }
        }
        return håndVærdi;
    }
    
    private void UddelStartKort()
    {
        UddelKortTilSpiller(dealer);
        UddelKortTilSpiller(dealer);
        UddelKortTilSpiller(spiller);
        UddelKortTilSpiller(spiller);
    }

    public int UdregnHånd(ReadOnlyCollection<Kort> hånd)
    {
        return UdregnHånd(new List<Kort>(hånd));
    }

    public int UdregnHånd(ISpiller spiller)
    {
        return UdregnHånd(spiller.GetROHånd());
    }

    private static int UdregnEsVærdi(int esVærdi, int håndVærdi)
    {
        if (håndVærdi < 11) {
            esVærdi = 11;
        } else {
            esVærdi = 1;
        }
        return esVærdi;
    }

    public void UddelKortTilSpiller(ISpiller spiller)
    {
        spiller.TilføjKort(deck.Træk());
    }
}