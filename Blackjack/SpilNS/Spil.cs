using Blackjack.KortNS;

namespace Blackjack.SpilNS;

public class Spil
{
    private List<ISpiller> spillere;
    private IDeck deck;

    public Spil()
    {
        spillere = new List<ISpiller>();
        deck = new Deck();
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
                    if (esVærdi == 0 && håndVærdi < 11)
                    {
                        esVærdi = 11;
                    } else if (esVærdi == 0)
                    {
                        esVærdi = 1;
                    }
                    håndVærdi += esVærdi;
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
    
    public void Setup()
    {
        spillere.Add(new Spiller());
        spillere.Add(new Spiller());
        deck.Bland();
        UddelKort(spillere[0]);
        UddelKort(spillere[1]);
        UddelKort(spillere[0]);
        UddelKort(spillere[1]);
    }

    public void UddelKort(ISpiller spiller)
    {
        spiller.TilføjKort(deck.Træk());
    }
}