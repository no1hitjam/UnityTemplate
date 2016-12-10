using System;
using UnityEngine;

public class JExampleBehaviour : JBehaviour
{
    int x;
    string y;

    public void Init(int x, Color c, string y)
    {
        this.x = x;
        this.y = y;
        //// (above is generated) //// -----------------------------------------------------------\


    }





    //// (below is generated) //// -----------------------------------------------------------\
    public static JExampleBehaviour AddTo(GameObject newGameObject, int x, Color c, string y) {
        var behaviour = newGameObject.AddComponent<JExampleBehaviour>();
        behaviour.Init(x, c, y);
        return behaviour;
    }

    public static JExampleBehaviour AddTo(Component component, int x, Color c, string y)
    {
        return AddTo(component.gameObject, x, c, y);
    }

    // JExampleBehaviour: private int x, Color c*, public static string y
}



public class JExampleBehaviour : : JBehaviour
{
    private int x;
    public static string y;

    public void Init(int x, Color c, string y)
    {
        this.x = x;
        this.y = y;
        //// ABOVE GENERATED FOR //// JExampleBehaviour: private int x, Color c, public static string y ////


    }

    //// BELOW GENERATED FOR //// JExampleBehaviour: private int x, Color c, public static string y \\\\
    public static JExampleBehaviour AddTo(GameObject newGameObject, int x, Color c, string y)
    {
        var behaviour = newGameObject.AddComponent < JExampleBehaviour> ();
        behaviour.Init(x, c, y);
        return behaviour;
    }

    public static JExampleBehaviour AddTo(Component component, int x, Color c, string y)
    {
        return AddTo(component.gameObject, x, c, y);
    }

}