class NahodnyHrac : HoubarovoChovani
{
    public NahodnyHrac()
    {
        // zde muzete dat kod spousteny jen jednou pri vytvareni houbare
    }

    // zde doplnte inteligenci vaseho houbare
    public override Smer pohyb(TypEntity[,] mapa, Pozice pozice)
    {
        // prvni argument funkce je 2D pole enumeratoru TypEntity
        // mozne hodnoty tohoto enumeratoru jsou
        // TypEntity.Houba, TypEntity.Houbar, TypEntity.Plot, TypEntity.Prazdno, TypEntity.Strom
        // viz soubor Entita.cs

        // druhy argument funkce je struktura Pozice
        // tato struktura ma clenske promenne pozice.i a pozice.j
        // take se k ni da pricist smer pomoci pozice.prictiSmer.
        // viz soubor Pozice.cs

        // pro vytisknuti toho, co houbar vidi pouzijte funkci ukazMapu
        // prosim nepouzivejte ji v odevzdavanem reseni
        // ukazMapu(mapa, pozice);

        // mate k dispozici nahodny generator pod nazvem rnd
        Smer s = (Smer)rnd.Next(6);

        // vratit musite enumerator s nazvem Smer. Mozne hodnoty jsou
        // Smer.Nahoru, Smer.Dolu, Smer.Doleva, Smer.Doprava, Smer.Stuj;
        return s;
    }
}