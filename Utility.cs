using System;
using System.Linq;
using System.Collections.Generic;

public static class Utility
{
    // rozsireni pro nahodne zamichani listu, muzete ignorovat
    public static List<T> Shuffle<T>(this List<T> l)
    {
        Random rnd = new Random();
        return l.OrderBy<T, int>((item) => rnd.Next()).ToList();
    }
}
