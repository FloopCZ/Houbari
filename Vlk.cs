using System;
using System.Threading;

class Vlk : Entita
{
    private Random rnd;

    public Vlk(Pozice p, char znak) : base(p, znak, TypEntity.Vlk)
    {
        // inicializuj nahodny generator napriklad pozici
        rnd = new Random(p.i * p.j);
    }

    public override void krok(Svet svet)
    {
        // vyber nahodnou pristi pozici 
        Smer s = (Smer)rnd.Next(6);
        Pozice nova_pozice = pozice.prictiSmer(s);
        if (svet.entitaNaPozici(nova_pozice) == null)
        {
            pozice = nova_pozice;
        }
        // sezer cloveka
        else if (svet.entitaNaPozici(nova_pozice).typ == TypEntity.Houbar)
        {  
            Entita hrac = svet.entitaNaPozici(nova_pozice);
            Console.WriteLine($"Ale ne! Vlk si dal hrace {hrac.znak} ke svacine!");
            Thread.Sleep(3000);
            svet.entity.Remove(hrac);
            pozice = nova_pozice;
        }
    }
}