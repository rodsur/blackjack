namespace Blackjack.Grænseflade;

public interface IGrænseflade
{
    public void SkrivBesked(String besked);
    public int PræsenterValg(String besked, int antalValgmuligheder);
}