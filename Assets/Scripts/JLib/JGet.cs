using System.Collections.Generic;
using UnityEngine;

public static class JGet
{
    public static T Behaviour<T>(GameObject gameObject)
        where T : JBehaviour
    {
        var b = gameObject.AddComponent<T>();
        return b;
    }
}

