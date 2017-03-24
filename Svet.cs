using System;
using System.Collections.Generic;
using System.Linq;

class Svet
{
    public Random rnd = new Random();
    public int M = 32;
    public int N = 52;
    public List<Entita> entity = new List<Entita>();

    int pocetHub()
    {
        return entity.Where(e => e.typ == TypEntity.Houba).Count();
    }

    void obnovHouby()
    {
        for (int i = pocetHub(); i < 20; ++i)
        {
            Pozice pozice = nahodnaVolnaPozice();
            entity.Add(new Houba(pozice, 'O'));
        }
    }

    public Svet(int M, int N, List<HoubarovoChovani> hraci)
    {
        this.M = M;
        this.N = N;

        // vytvor svisly plot
        for (int i = 1; i < M - 1; ++i)
        {
            entity.Add(new Plot(new Pozice(i, 0), '|'));
            entity.Add(new Plot(new Pozice(i, N - 1), '|'));
        }
        // vytvor horizontalni plot
        for (int i = 1; i < N - 1; ++i)
        {
            entity.Add(new Plot(new Pozice(0, i), '-'));
            entity.Add(new Plot(new Pozice(M - 1, i), '-'));
        }
        // vytvor stromy
        for (int i = 1; i < 100; ++i)
        {
            Pozice pozice = nahodnaVolnaPozice();
            entity.Add(new Strom(pozice, 'T'));
        }
        // vytvor vlky
        for (int i = 0; i < 10; ++i)
        {
            Pozice pozice = nahodnaVolnaPozice();
            Vlk vlk = new Vlk(pozice, 'V');
            entity.Add(vlk);
        }
        // vytvor houbare
        for (int i = 1; i <= hraci.Count; ++i)
        {
            Pozice pozice = nahodnaVolnaPozice();
            Houbar houbar = new Houbar(pozice, hraci[i - 1], (char)(i + '0'));
            entity.Add(houbar);
        }
        // vytvor houby
        obnovHouby();
    }

    public void krok()
    {
        entity.Shuffle();
        for (int i = 0; i < entity.Count; ++i)
        {
            entity[i].krok(this);
        }
    }

    public void ukazMapu()
    {
        char[,] mapa = new char[M, N];
        // vypln mapu mezerniky
        for (int i = 0; i < M; ++i)
        {
            for (int j = 0; j < N; ++j)
            {
                mapa[i, j] = ' ';
            }
        }
        // pridej do mapy entity
        foreach (Entita e in entity)
        {
            mapa[e.pozice.i, e.pozice.j] = e.znak;
        }
        // vytiskni mapu
        for (int i = 0; i < M; ++i)
        {
            for (int j = 0; j < N; ++j)
            {
                Console.Write(mapa[i, j]);
            }
            Console.Write('\n');
        }
        // ukaz reporty
        foreach (Entita e in entity)
        {
            e.report(this);
        }
    }

    public Entita entitaNaPozici(Pozice p)
    {
        foreach (Entita e in entity)
        {
            if (e.pozice.i == p.i && e.pozice.j == p.j)
                return e;
        }
        return null;
    }

    public Pozice nahodnaVolnaPozice()
    {
        // generuj nahodne souradnice dokud netrefis prazdne misto
        int i, j;
        do
        {
            i = rnd.Next(1, M - 1);
            j = rnd.Next(1, N - 1);
        } while (entitaNaPozici(new Pozice(i, j)) != null);
        return new Pozice(i, j);
    }
}
