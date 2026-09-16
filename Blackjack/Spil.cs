using System.ComponentModel;
using Blackjack.KortNS;

namespace Blackjack;

public class Spil
{
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
}