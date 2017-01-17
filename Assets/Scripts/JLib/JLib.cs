﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public static class JLib
{
    // -- enums --
    public enum TextFitMode { StretchX, ShrinkX, StretchY, ShrinkY }
    

    // -- Constants --
    public readonly static Vector3 AxesAll = Vector3.one;
    public readonly static Vector3 Axes2D = new Vector3(1, 1, 0);

    // -- Axes --

    public static Vector3 Axes(bool x, bool y, bool z)
    {
        return new Vector3(x ? 1 : 0, y ? 1 : 0, z ? 1 : 0);
    }

    /// <summary>
    /// Rounds each float to 0 or 1 from 0 or not-zero.
    /// Sets null to all
    /// </summary>
    public static Vector3 ReduceToAxes(Vector3? v)
    {
        if (!v.HasValue)
            return AxesAll;
        return new Vector3(v.Value.x < .0001 ? 0 : 1, v.Value.y < .0001 ? 0 : 1, v.Value.z < .0001 ? 0 : 1);
    }

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
        For(0, iterations, action);
    }

    /// <param name="step">defaults to increment</param>
    public static void For(int start, int iterations, UnityAction<int> action)
    {
        for (int i = start; i < start + iterations; i++) {
            action(i);
        }
    }

}

