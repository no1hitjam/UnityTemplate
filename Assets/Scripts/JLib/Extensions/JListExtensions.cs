using System;
using System.Collections.Generic;
using UnityEngine;

public static class JListExtensions
{
    /// <param name="constructor">int is list index</param>
    public static List<T> AddRange<T> (this List<T> list, int count, Func<int,T> constructor)
    {
        JLib.For(count, () =>
        {
            list.Add(constructor(list.Count));
        });
        return list;
    }

    /// <summary>
    /// Names componenets according to list index
    /// </summary>
    /// <param name="constructor">int is list index</param>
    public static List<T> AddComponents<T>(this List<T> list, int count, Func<int, T> constructor)
        where T : Component
    {
        JLib.For(count, () =>
        {
            list.Add(constructor(list.Count));
            if (typeof(T).IsSubclassOf(typeof(Component))) {
                list.Get(-1).GetOrAdd<JName>().SetListIndex(list.Count - 1);
            }
        });
        return list;
    }

    /// <summary>
    /// If JRoll, use this to access members without offset
    /// </summary>
    /// <param name="index">rolls if out of bounds</param>
    public static T Get<T> (this List<T> list, int index)
    {
        return list[JLib.Mod(index, list.Count)];
    }

}
