public enum Smer { Nahoru, Dolu, Doleva, Doprava, Stuj };

public struct Pozice
{
    public int i;
    public int j;

    public Pozice(int i, int j)
    {
        this.i = i;
        this.j = j;
    }
    public Pozice prictiSmer(Smer s)
    {
        Pozice nova = this;
        switch (s)
        {
            case Smer.Doleva:
                --nova.j;
                break;
            case Smer.Doprava:
                ++nova.j;
                break;
            case Smer.Nahoru:
                --nova.i;
                break;
            case Smer.Dolu:
                ++nova.i;
                break;
        }
        return nova;
    }
}