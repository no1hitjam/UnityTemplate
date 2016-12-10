using System.Collections.Generic;
using UnityEngine.Events;
public static class JLib
{
    public static int Mod(int n, int mod)
    {
        while (n < 0)
            n += mod;
        return n % mod;
    }

    public static void For(int iterations, UnityAction<int> action)
    {
        for (int i = 0; i < iterations; i++) {
            action(i);
        }
    }
}

