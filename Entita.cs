enum TypEntity {Prazdno, Plot, Strom, Houba, Vlk, Houbar };

class Entita
{
    public Entita(Pozice p, char znak, TypEntity typ)
    {
        this.znak = znak;
        this.pozice = p;
        this.typ = typ;
    }

    // znak kterym se entita vykresli na mapu
    public char znak;
    // identifikator
    public TypEntity typ;
    // souradnice
    public Pozice pozice;

    public virtual void krok(Svet svet)
    {
        // zakladni funkce krok() nic nedela
    }

    public virtual void report(Svet svet)
    {
    }
}