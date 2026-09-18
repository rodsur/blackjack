using Blackjack.SpilNS;

namespace Blackjack;

class Program
{
    static void Main(string[] args)
    {
        Spil spil = new Spil();
        spil.Setup();
        ISpiller dealer = spil.GetROSpillere()[0];
        ISpiller spiller = spil.GetROSpillere()[1];
        bool spilIgang = true;
        while (spilIgang)
        {
            Console.WriteLine("Du har følgende kort:");
            foreach (var kort in spiller.GetROHånd())
            {
                Console.WriteLine(kort);
            }
            Console.WriteLine("De har en værdi på: " + spil.UdregnHånd(spiller));
            Console.WriteLine("Dealeren har følgende kort:");
            foreach (var kort in spiller.GetROHånd())
            {
                Console.WriteLine(kort);
            }
            Console.WriteLine("Dealeren har kort værdi på: " + spil.UdregnHånd(dealer));
            Console.WriteLine("Hvad ønsker du at gøre?");
            String brugerValg = Console.ReadLine() ?? "";
            switch (brugerValg)
            {
                case "1":
                    spil.UddelKortTilSpiller(spiller);
                    if (spil.UdregnHånd(spiller) > 21)
                    {
                        Console.WriteLine("Du har mere end 21 point, du har tabt");
                        spilIgang = false;
                    } else if (spil.UdregnHånd(spiller) == 21)
                    {
                        Console.WriteLine("Du fik 21, tillykke du har vundet!");
                    }
                    break;
                case "2":
                    int spillerPoint = spil.UdregnHånd(spiller);
                    int dealerPoint = spil.UdregnHånd(dealer);
                    if (dealerPoint > spillerPoint)
                    {
                        Console.WriteLine("Du tabte til dealeren");
                    } else if (spillerPoint > dealerPoint)
                    {
                        Console.WriteLine("Tillykke du vandt over dealeren");
                    }
                    else
                    {
                        Console.WriteLine("I stod lige, bedre held næste gang");
                    }

                    spilIgang = false;
                    break;
                case "x":
                    spilIgang = false;
                    Console.WriteLine("Farvel");
                    break;
            }
        }
    }
}