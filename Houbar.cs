using System;
using System.Threading;

class Houbar : Entita
{
    public int pocet_hub = 0;
    public int viditelnost = 4;

    public Houbar(Pozice p, HoubarovoChovani chovani, char znak)
      : base(p, znak, TypEntity.Houbar)
    {
        this.chovani = chovani;
    }

    private HoubarovoChovani chovani;

    private TypEntity[,] mapaViditelnosti(Svet svet)
    {
        TypEntity[,] mapa = new TypEntity[svet.M, svet.N];
        foreach (Entita e in svet.entity)
        {
            // stromy a plot jsou videt vsude, ostatni jen blizko
            if (   e.typ == TypEntity.Strom
                || e.typ == TypEntity.Plot
                || (   Math.Abs(e.pozice.i - pozice.i) <= viditelnost
                    && Math.Abs(e.pozice.j - pozice.j) <= viditelnost))
            {
                mapa[e.pozice.i, e.pozice.j] = e.typ;
            }
        }
        return mapa;
    }

    public override void krok(Svet svet)
    {
        TypEntity[,] mapa = mapaViditelnosti(svet);
        Smer chteny_smer = Smer.Stuj;
        try {
            chteny_smer = chovani.pohyb(mapa, pozice);
        } catch (Exception e) {
            Console.WriteLine($"Hrac {znak} provedl neplatnou operaci: {e.ToString()}");
            Thread.Sleep(1500);
        }
        Pozice nova_pozice = pozice.prictiSmer(chteny_smer);
        // zkontroluj, ze timto smerem muze houbar jit
        if (svet.entitaNaPozici(nova_pozice) == null)
        {
            pozice = nova_pozice;
        }
        // seber houbu
        else if (svet.entitaNaPozici(nova_pozice).typ == TypEntity.Houba)
        {
            Console.WriteLine($"Vyborne, hrac {znak} sebral houbu!");
            Thread.Sleep(1500);
            svet.entity.Remove(svet.entitaNaPozici(nova_pozice));
            pozice = nova_pozice;
            ++pocet_hub;
        }
    }

    public override void report(Svet svet)
    {
        Console.WriteLine($"Hrac {znak} ma {pocet_hub} hub.");
    }
}


abstract class HoubarovoChovani
{
    public Random rnd;

    public HoubarovoChovani()
    {
        // inicializuj nahodny generator nejakym unikatnim cislem
        rnd = new Random(Guid.NewGuid().GetHashCode());
    }

    // tuto virtualni funkci je treba implementovat
    public abstract Smer pohyb(TypEntity[,] mapa, Pozice p);

    public static void ukazMapu(TypEntity[,] mapa, Pozice p)
    {
        for (int i = 0; i < mapa.GetLength(0); ++i)
        {
            for (int j = 0; j < mapa.GetLength(1); ++j)
            {
                switch(mapa[i, j])
                {
                    case TypEntity.Houba:
                        Console.Write('O');
                        break;
                    case TypEntity.Houbar:
                        Console.Write('H');
                        break;
                    case TypEntity.Vlk:
                        Console.Write('V');
                        break;
                    case TypEntity.Strom:
                        Console.Write('T');
                        break;
                    case TypEntity.Plot:
                        Console.Write('P');
                        break;
                    default:
                        Console.Write(' ');
                        break;
                }
            }
            Console.Write('\n');
        }
        Console.Write('\n');
    }
}