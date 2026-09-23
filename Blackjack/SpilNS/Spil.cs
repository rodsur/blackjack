using System.Collections.ObjectModel;
using System.Text;
using Blackjack.Grænseflade;
using Blackjack.KortNS;

namespace Blackjack.SpilNS;

public class Spil
{
    private ISpiller dealer;
    private ISpiller spiller;
    private IDeck deck;
    private IGrænseflade grænseflade;
    
    public Spil(IGrænseflade grænseflade, ISpiller dealer, ISpiller spiller, IDeck deck)
    {
        this.grænseflade = grænseflade;
        this.dealer = dealer;
        this.spiller = spiller;
        this.deck = deck;
    }
    
    public void SpilLoop()
    {
        deck.Bland();
        UddelStartKort();
        bool dealerUde = false;
        bool spillerUde = false;
        while (!dealerUde && !spillerUde)
        {
            OplysSpillerOmKortOgVærdi();
            int brugerValg = HitEllerStand();
            switch (brugerValg)
            {
                case 1:
                    UddelKortTilSpiller(spiller);
                    if (UdregnHånd(spiller) > 21)
                    {
                        spillerUde = true;
                    }
                    break;
                case 2:
                    spillerUde = true;
                    break;
            }

            dealerUde = DealerHandling(dealerUde);
        }
        UdregnOgPræsenterVinder(UdregnHånd(spiller), UdregnHånd(dealer));
    }

    private bool DealerHandling(bool dealerUde)
    {
        if (SkalDealerHit())
        {
            UddelKortTilSpiller(dealer);
            if (UdregnHånd(dealer) > 21)
            {
                dealerUde = true;
            }
        }
        else
        {
            dealerUde = true;
        }

        return dealerUde;
    }

    private void UdregnOgPræsenterVinder(int spillerPoint, int dealerPoint)
    {
        grænseflade.SkrivBesked("Du har: " + spillerPoint + " og dealeren har: " + dealerPoint);
        if (dealerPoint > 21 && spillerPoint > 21)
        {
            grænseflade.SkrivBesked("I gik begge bust, bedre held næste gang");
        } else if (spillerPoint > 21)
        {
            grænseflade.SkrivBesked("Du er bust, bedre held næste gang");
        } else if (dealerPoint > 21)
        {
            grænseflade.SkrivBesked("Dealeren er bust, tillykke du vandt");
        } else if (dealerPoint == spillerPoint)
        {
            grænseflade.SkrivBesked("I stod lige, bedre held næste gang");
        } else if (dealerPoint > spillerPoint)
        {
            grænseflade.SkrivBesked("Dealeren vandt, bedre held næste gang");
        } else if (dealerPoint < spillerPoint)
        {
            grænseflade.SkrivBesked("Du vandt over dealeren, tillykke");
        }
    }

    private bool SkalDealerHit()
    {
        if (UdregnHånd(spiller) > 21)
        {
            return false;
        }
        return UdregnHånd(dealer) < 17 || (UdregnHånd(spiller) >= UdregnHånd(dealer));
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