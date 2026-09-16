namespace Blackjack.KortNS;

public class Kort
{
    private Værdi værdi;
    private Kulør kulør;
    public enum Kulør
    {
        Hjerter,
        Spar,
        Klør,
        Ruder
    }
    public enum Værdi
    {
        Es = 1,
        To,
        Tre,
        Fire,
        Fem,
        Seks,
        Syv,
        Otte,
        Ni,
        Ti,
        Knægt = 10,
        Dronning = 10,
        Konge = 10
    }

    public Kort(Værdi værdi, Kulør kulør)
    {
        this.værdi = værdi;
        this.kulør = kulør;
    }

    public override string ToString()
    {
        return kulør + " " + værdi;
    }

    public Kulør getKulør()
    {
        return kulør;
    }

    public Værdi getVærdi()
    {
        return værdi;
    }
}