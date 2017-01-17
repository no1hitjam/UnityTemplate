using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public static class JLib
{
    // -- enums --
    public enum Axis { X, Y, Z }

    // -- JBehaviour --

    public static T New<T>(string name = "New GameObject") 
        where T : MonoBehaviour
    {
        var component = new GameObject().AddComponent<T>();
        component.Add<JName>().SetBaseName(name);
        return component;
    }

    // -- iteration --

    public static void For(int iterations, UnityAction<int> action)
    {
        for (int i = 0; i < iterations; i++) {
            action(i);
        }
    }

    public static void For(int iterations, UnityAction action)
    {
        for (int i = 0; i < iterations; i++) {
            action();
        }
    }

    public static void For<T>(ICollection<T> list, UnityAction<int, T> action)
    {
        int index = 0;
        foreach (var item in list) {
            action(index, item);
            index++;
        }
    }

    // -- math --

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

    

    // -- vectors --

    public static Vector3 Scale(Vector3 v, Vector3 scale)
    {
        v.Scale(scale);
        return v;
    }

    public static float GetAxis(Vector3 v, Axis a)
    {
        if (a == Axis.X)
            return v.x;
        if (a == Axis.Y)
            return v.y;
        return v.z;
    }

    public static Vector3 SetAxis(Vector3 v, Axis a, float f)
    {
        return SetAxis(v, a, (float _) => f);
    }
    public static Vector3 SetAxis(Vector3 v, Axis a, Func<float, float> func)
    {
        if (a == Axis.X)
            v.x = func(v.x);
        else if (a == Axis.Y)
            v.y = func(v.y);
        else
            v.z = func(v.z);
        return v;
    }

    

    // -- making new stuff --

    public static JRender NewSpriteRenderer(Transform parent, Sprite sprite = null, Color? color = null, Vector3? scale = null)
    {
        var render = NewRender(new GameObject().AddComponent<SpriteRenderer>().gameObject, parent, sprite, null, color, scale);
        return render;
    }

    public static JRender NewImage(Transform parent, float width, float height, Sprite sprite = null, Color? color = null, Vector3? scale = null)
    {
        var render = NewRender(new GameObject().AddComponent<Image>().gameObject, parent, sprite, null, color, scale);
        render.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        return render;
    }

    public static JRender NewSpriteRenderer(Transform parent, JList<Sprite> sprites, int spriteIndex, Color? color = null, Vector3? scale = null)
    {
        var render = NewRender(new GameObject().AddComponent<SpriteRenderer>().gameObject, parent, null, sprites, color, scale);
        render.spriteIndex = spriteIndex;
        return render;
    }

    public static JRender NewImage(Transform parent, float width, float height, JList<Sprite> sprites, int spriteIndex, Color? color = null, Vector3? scale = null)
    {
        var render = NewRender(new GameObject().AddComponent<Image>().gameObject, parent, null, sprites, color, scale);
        render.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        render.spriteIndex = spriteIndex;
        return render;
    }

    private static JRender NewRender(GameObject obj, Transform parent, Sprite sprite, JList<Sprite> sprites, Color? color, Vector3? scale)
    {
        var render = obj.AddComponent<JRender>();
        render.transform.SetParent(parent, false);
        render.sprite = sprite;
        render.sprites = sprites;
        if (color.HasValue)
            render.color = color.Value;
        if (scale.HasValue)
            render.transform.localScale = scale.Value;
        return render;
    }

    

    
}

