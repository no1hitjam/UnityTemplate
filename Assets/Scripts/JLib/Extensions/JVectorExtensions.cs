using System;
using System.Collections.Generic;
using UnityEngine;

public static class JVectorExtensions
{
    /// <summary>
    /// Does not affect arguments
    /// </summary>
    public static Vector3 NewScale(this Vector3 v, Vector3 scale)
    {
        return new Vector3(v.x * scale.x, v.y * scale.y, v.z * scale.z);
    }

    public static Vector3 NewScale(this Vector2 v, Vector2 scale)
    {
        return new Vector2(v.x * scale.x, v.y * scale.y);
    }

    /// <summary>
    /// Does not affect arguments
    /// </summary>
    public static Vector2 JScale(this Vector2 v, Vector2 scale)
    {
        return new Vector2(v.x * scale.x, v.y * scale.y);
    }

    /// <param name="axes">default: all</param>
    public static float JDistance(this Vector3 v, Vector3 to, Vector3? axes = null)
    {
        axes = JLib.ReduceToAxes(axes);
        return Vector3.Distance(v.NewScale(axes.Value), to.NewScale(axes.Value));
    }

    public static int NumAxes(this Vector3 v)
    {
        v = JLib.ReduceToAxes(v);
        return (int)(v.x + v.y + v.z);
    }
    public static float Magnitude(this Vector3 v, Vector3 axes)
    {
        return v.NewScale(axes).magnitude;
    }

    public static float Magnitude(this Vector2 v, Vector3 axes)
    {
        return v.NewScale(axes).magnitude;
    }

    /*
    public static float GetAxis(this Vector3 vector, JLib.Axis axis)
    {
        if (axis == JLib.Axis.X) {
            return vector.x;
        } else if (axis == JLib.Axis.Y) {
            return vector.y;
        }
        return vector.z;
    }

    public static Vector3 SetAxis(this Vector3 vector, JLib.Axis axis, float value)
    {
        return vector.SetAxis(axis, (f) => { return value; });
    }

    public static Vector3 SetAxis(this Vector3 vector, JLib.Axis axis, Func<float, float> value)
    {
        if (axis == JLib.Axis.X) {
            vector.x = value(vector.x);
        } else if (axis == JLib.Axis.Y) {
            vector.y = value(vector.y);
        } else {
            vector.z = value(vector.z);
        }
        return vector;
    }

    public static float GetAxis(this Vector2 vector, JLib.Axis axis)
    {
        if (axis == JLib.Axis.X)
            return vector.x;
        if (axis == JLib.Axis.Y)
            return vector.y;
        return 0;
    }

    public static Vector2 SetAxis(this Vector2 vector, JLib.Axis axis, float value)
    {
        return vector.SetAxis(axis, (f) => { return value; });
    }

    public static Vector2 SetAxis(this Vector2 vector, JLib.Axis axis, Func<float, float> value)
    {
        if (axis == JLib.Axis.X) {
            vector.x = value(vector.x);
        } else if (axis == JLib.Axis.Y) {
            vector.y = value(vector.y);
        }
        return vector;
    }*/
}