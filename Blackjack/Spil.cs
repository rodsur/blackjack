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
            if (kort.getVærdi() == Kort.Værdi.Es)
            {
                if (esVærdi == 0)
                {
                    if (håndVærdi < 11)
                    {
                        esVærdi = 11;
                    }
                    else
                    {
                        esVærdi = 1;
                    }
                }

                håndVærdi += esVærdi;
                continue;
            }
            håndVærdi += (int)kort.getVærdi();
        }
        return håndVærdi;
    }
}