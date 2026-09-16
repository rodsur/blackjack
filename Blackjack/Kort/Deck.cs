namespace Blackjack.Kort;

public class Deck : IDeck
{
    private List<Kort> deck;

    public Deck()
    {
        deck = new List<Kort>();
        foreach (Kort.Kulør kulør in Enum.GetValues<Kort.Kulør>())
        {
            foreach (Kort.Værdi værdi in Enum.GetValues<Kort.Værdi>())
            {
                deck.Add(new Kort(værdi, kulør));
            }
        }
    }

    public Kort Træk()
    {
        if (deck.Count == 0)
        {
            throw new InvalidOperationException("Der var ikke flere kort");
        }
        Kort kort = deck[0];
        deck.RemoveAt(0);
        return kort;
    }

    public void Shuffle()
    {
        deck = deck.Shuffle().ToList();
    }
}