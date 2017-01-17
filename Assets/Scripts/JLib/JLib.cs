using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public static class JLib
{
    // -- enums --
    public enum Axis { X, Y, Z }
    public enum TextFitMode { StretchX, ShrinkX, StretchY, ShrinkY }

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

