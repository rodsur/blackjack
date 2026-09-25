using System.Collections.ObjectModel;
using Blackjack.KortNS;

namespace Blackjack.SpilNS;

public interface ISpiller
{
    void TilføjKort(Kort kort);
    ReadOnlyCollection<Kort> GetROHånd();
}