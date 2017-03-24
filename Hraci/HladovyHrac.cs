class HladovyHrac : HoubarovoChovani
{
    public HladovyHrac()
    {
    }

    // zde doplnte inteligenci vaseho houbare
    public override Smer pohyb(TypEntity[,] mapa, Pozice pozice)
    {
        // s urcitou pravdepodobnosti se pohni nahodne
        if (rnd.Next(10) < 3) {
            return (Smer)rnd.Next(6);
        }

        // jinak hladove
        for (int i = 0; i <= 3; ++i) {
            // je dole houba?
            if (pozice.i + i < 32 && mapa[pozice.i + i, pozice.j] == TypEntity.Houba)
                return Smer.Dolu;
            // je nahore houba?
            if (pozice.i - i >= 0 && mapa[pozice.i - i, pozice.j] == TypEntity.Houba)
                return Smer.Nahoru;
            // je vpravo houba?
            if (pozice.j + i < 32 && mapa[pozice.i, pozice.j + i] == TypEntity.Houba)
                return Smer.Doprava;
            // je vlevo houba?
            if (pozice.j - i >= 0 && mapa[pozice.i, pozice.j - i] == TypEntity.Houba)
                return Smer.Doleva;
        }

        // kdyz jsem nevidel houbu, zase nahodne
        return (Smer)rnd.Next(6);
    }
}