using System.Collections.ObjectModel;
using Blackjack.KortNS;

namespace Blackjack.SpilNS;

public class Spiller : ISpiller
{
    private List<Kort> hånd;

    public void TilføjKort(Kort kort)
    {
        hånd.Add(kort);
    }

    public ReadOnlyCollection<Kort> GetROHånd()
    {
        return hånd.AsReadOnly();
    }
}