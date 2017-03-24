using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static int epoch = 1000;

    static void Main(string[] args)
    {
        // vytvor nahodne hrace
        List<HoubarovoChovani> hraci = new List<HoubarovoChovani>();
        hraci.Add(new NahodnyHrac());
        hraci.Add(new NahodnyHrac());
        hraci.Add(new HladovyHrac());
        hraci.Add(new HladovyHrac());
        hraci.Add(new HladovyHrac());
        hraci.Add(new HladovyHrac());
        hraci.Add(new HladovyHrac());

        Svet s = new Svet(32, 32, hraci);
        for (int i = 0; i < epoch; ++i)
        {
            s.ukazMapu();
            s.krok();
            Thread.Sleep(200);
            Console.Clear();
        }
    }
}
