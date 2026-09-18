using System.Collections.ObjectModel;
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

    public void Setup()
    {
        TilføjSpillere(2);
        deck.Bland();
        UddelKortTilAlleSpillere(2);
    }

    private void TilføjSpillere(int antalSpillere)
    {
        for (int i = 0; i < antalSpillere; i++)
        {
            spillere.Add(new Spiller());
        }
    }

    private void UddelKortTilAlleSpillere(int antalKort)
    {
        for (int kortUddelt = 0; kortUddelt < antalKort; kortUddelt++)
        {
            foreach(var spiller in spillere)
            {
                UddelKortTilSpiller(spiller);
            }
        }
    }

    public void UddelKortTilSpiller(ISpiller spiller)
    {
        spiller.TilføjKort(deck.Træk());
    }

    public ReadOnlyCollection<ISpiller> GetROSpillere()
    {
        return spillere.AsReadOnly();
    } 
}