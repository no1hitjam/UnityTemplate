﻿
public static class JMath
{
    public static int Mod(int n, int mod)
    {
        while (n < 0)
            n += mod;
        return n % mod;
    }

    private static JDic<string, System.Random> rngs = new JDic<string, System.Random>();

    public static int Random(int min, int max, string rng_name = "default")
    {
        var rng = rngs.ContainsKey(rng_name) ? rngs[rng_name] : new System.Random();
        return rng.Next(min, max);
    }

    public static float Random(float min = 0, float max = 1, string rng_name = "default")
    {
        var rng = rngs.ContainsKey(rng_name) ? rngs[rng_name] : new System.Random();
        return (float)rng.NextDouble() * (max - min) + min;
    }

    public static void SetRNG(string name, int? seed = null)
    {
        if (seed.HasValue) {
            rngs[name] = new System.Random(seed.Value);
        } else {
            rngs[name] = new System.Random();
        }
    }
}

