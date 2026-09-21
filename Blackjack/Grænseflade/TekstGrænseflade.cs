using Microsoft.VisualBasic.CompilerServices;

namespace Blackjack.Grænseflade;

public class TekstGrænseflade : IGrænseflade
{
    public void SkrivBesked(string besked)
    {
        Console.WriteLine(besked);
    }

    public int PræsenterValg(string besked, int antalValgmuligheder)
    {
        bool inputHåndteret = false;
        int inputInt = 0;
        while (!inputHåndteret)
        {
            Console.WriteLine(besked);
            String input = Console.ReadLine() ?? "";
            inputInt = IntegerType.FromString(input);
            if (inputInt < 1 || inputInt > antalValgmuligheder)
            {
                Console.WriteLine("Ugyldigt valg");
            }
            else
            {
                inputHåndteret = true;
            }
        }
        return inputInt;
    }
}